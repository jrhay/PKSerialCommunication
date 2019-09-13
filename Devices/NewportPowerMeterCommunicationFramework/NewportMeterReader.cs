using SerialCommunicationFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace NewportPowerMeterCommunicationFramework
{
    /// <summary>
    /// Class to implement a single-source reader for Newport Power Meters
    /// This allows multiple threads to read values from the power meter simultaneously by
    /// performing its own reads and responding to the threads itself.
    /// </summary>
    public class NewportMeterReader
    {
        #region Events

        /// <summary>
        /// Delegate called when connecting or disconnecting from a Newport power meter
        /// </summary>
        /// <param name="Meter">Meter instance used for connection</param>
        public delegate void MeterReaderEventHandler(NewportMeter<BaseSerialPort> Meter);
        event MeterReaderEventHandler MeterConnecting;
        event MeterReaderEventHandler MeterDisconneting;

        /// <summary>
        /// Event called when the reader has opened a new connection to a power meter. This will be called before the 
        /// background reading thread is started.
        /// </summary>
        public event MeterReaderEventHandler OnPowerMeterConnecting
        {
            add { MeterConnecting += value; }
            remove { MeterConnecting -= value; }
        }

        /// <summary>
        /// Event called when the reader disconnects from a previously-connected power meter.  This will be called after the
        /// background reading thread has ended.
        /// </summary>
        public event MeterReaderEventHandler OnPowerMeterDisconnecting
        {
            add { MeterDisconneting += value; }
            remove { MeterDisconneting -= value; }
        }

        /// <summary>
        /// Delegate to handle errors when attempting to connect to a new power meter
        /// </summary>
        /// <param name="Message">Connection error message.  If NULL, indicates an error finding a connected power meter
        /// (on the specified COM port, if one was specified).  Otherwise, indicates an error opening the COM port, etc.</param>
        public delegate void MeterReaderConnectErrorHandler(String Message);
        event MeterReaderConnectErrorHandler MeterUnableToConnect;

        /// <summary>
        /// Event called when unable to connect to a power meter / find a connected power meter
        /// </summary>
        public event MeterReaderConnectErrorHandler OnPowerMeterUnableToConnect
        {
            add { MeterUnableToConnect += value; }
            remove { MeterUnableToConnect -= value; }
        }

        /// <summary>
        /// Delegate to handle errors communicating with a power meter
        /// </summary>
        /// <param name="MeterReader">NewportMeterReader instance generating this event</param>
        /// <param name="ErrorMessage">Error Message</param>
        /// <param name="ErrorCode">Code for error, if known (-1 if unknown)</param>
        public delegate void MeterReaderErrorHandler(NewportMeterReader MeterReader, String ErrorMessage, int ErrorCode);
        event MeterReaderErrorHandler ErrorHandler;

        /// <summary>
        /// Event called when a power meter error occurs.
        /// </summary>
        public event MeterReaderErrorHandler OnPowerMeterError
        {
            add { ErrorHandler += value; }
            remove { ErrorHandler -= value; }
        }

        #endregion

        #region Lifecycle

        NewportMeter<BaseSerialPort> Meter = null;

        /// <summary>
        /// Create a new NewportMeterReader instance, not connected to any meter
        /// </summary>
        public NewportMeterReader()
        {
        }

        /// <summary>
        /// Stop taking readings from any connected power meter.  The Reading property will still contain the
        /// last reading from the meter.
        /// </summary>
        public void StopReading()
        {
            if (Meter != null)
            {
                StopBackgroundReadingThread();

                MeterDisconneting?.Invoke(Meter);
                Meter.Dispose();
                Meter = null;
            }
        }

        /// <summary>
        /// Open a connection to the power meter and start taking readings.
        /// </summary>
        /// <param name="COMPort">System COM port to open, must be a valid system serial port</param>
        public async void StartReadingAsync(String COMPort = null)
        {
            StopReading();

            if (String.IsNullOrEmpty(COMPort))
            {
                MeterUnableToConnect?.Invoke(null);
            }
            else
            {
                // Wait a bit to let connection settle
                System.Threading.Thread.Sleep(250);

                try
                {
                    Meter = await System.Threading.Tasks.Task.Run(() =>
                    {
                        Meter = new NewportMeter<BaseSerialPort>(COMPort);
                        Meter.OnPowerMeterError += Meter_OnPowerMeterError;
                        MeterConnecting?.Invoke(Meter);

                        StartBackgroundReadingThread();
                        return Meter;
                    });
                }
                catch (System.UnauthorizedAccessException e)
                {
                    MeterUnableToConnect?.Invoke(e.Message);
                }
            }
        }

        /// <summary>
        /// Bubble up power meter errors
        /// </summary>
        private void Meter_OnPowerMeterError(NewportMeter<BaseSerialPort> PowerMeter, string ErrorMessage, int ErrorCode)
        {
            if (ErrorHandler != null)
                ErrorHandler.Invoke(this, ErrorMessage, ErrorCode);
        }

        #endregion

        #region Power Meter Operations

        // Synchronization object
        private Object PowerMeterReadingLock = new object();

        private double _Reading;
        /// <summary>
        /// The last value read from the power meter
        /// </summary>
        public double Reading
        {
            get
            {
                lock (PowerMeterReadingLock)
                {
                    return _Reading;
                }
            }
            private set
            {
                lock (PowerMeterReadingLock)
                {
                    _Reading = value;
                }
            }
        }

        /// <summary>
        /// Is the reader conneted and actively reading from a power meter?
        /// </summary>
        public Boolean IsReading
        {
            get { return (Meter != null); }
        }

        #endregion

        #region Background Reading Thread

        BackgroundWorker readingThread = null;

        private void StartBackgroundReadingThread()
        {
            StopBackgroundReadingThread();

            readingThread = new BackgroundWorker();
            readingThread.WorkerSupportsCancellation = true;
            readingThread.DoWork += ReadingThread_DoWork;
            readingThread.RunWorkerCompleted += ReadingThread_RunWorkerCompleted;
            readingThread.RunWorkerAsync();
        }

        private void ReadingThread_DoWork(object sender, DoWorkEventArgs e)
        {
            while ((Meter != null) && !readingThread.CancellationPending)
            {
                double Value = Meter.GetPowerInBackground();
                if (!double.IsNaN(Value) || !double.IsInfinity(Value))
                    this.Reading = Value;

                Thread.Sleep(100);
            }
            e.Cancel = readingThread.CancellationPending;
        }

        private void ReadingThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ErrorHandler?.Invoke(this, e.Error.Message, 0);
            }

            readingThread = null;
        }

        private void StopBackgroundReadingThread()
        {
            if (readingThread != null)
                readingThread.CancelAsync();
        }

        #endregion

        #region Utility Methods

        /// <summary>
        /// Returns a string representing a given power reading with appropriate SI unit prefix
        /// Note: The exact SI unit splitting differs from that shown on the meter face
        /// </summary>
        /// <param name="Power">Power Reading</param>
        /// <param name="Unit">Base Units ("W", etc)</param>
        /// <returns>String with Power expressed with appropriate SI units of BaseUnit</returns>
        public static String PowerAsSIString(double Power, String Unit)
        {
            // Based on code from https://stackoverflow.com/questions/12181024/formatting-a-number-with-a-metric-prefix
            char[] incPrefixes = new[] { 'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
            char[] decPrefixes = new[] { 'm', '\u03bc', 'n', 'p', 'f', 'a', 'z', 'y' };

            if ((Power == 0) || (Power == double.MinValue) || (Power == double.MaxValue) || double.IsInfinity(Power) || double.IsNaN(Power))
                return Power.ToString() + " " + Unit;

            int degree = (int)Math.Floor(Math.Log10(Math.Abs(Power)) / 3);
            double scaled = Power * Math.Pow(1000, -degree);

            if ((degree > 8) || (degree < -8) || (degree == 0))
                return Power.ToString("G") + " " + Unit;

            char prefix = (Math.Sign(degree) == 1) ? incPrefixes[degree - 1] : decPrefixes[-degree - 1];
            return scaled.ToString("F3") + " " + prefix + Unit;
        }

        #endregion

    }
}
