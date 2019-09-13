using NewportPowerMeterCommunicationFramework.DataTypes;
using NewportPowerMeterCommunicationFramework.Exceptions;
using SerialCommunicationFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewportPowerMeterCommunicationFramework
{
    /// <summary>
    /// Class to encapsulate communication with a Newport 1931-C Power Meter over a COM port
    /// </summary>
    /// <typeparam name="Port"></typeparam>
    public class NewportMeter<Port> : IDisposable where Port : ISerialPort, new()
    {
        #region Lifecycle

        // Don't allow a null constructor
        private NewportMeter()
        {
            SerialPort = new Port();
            GeneratingEvents = true;
        }

        /// <summary>
        /// Attempt to connect to a Newport Power Meter on the given serial port.  
        /// Throws exceptions on any error opening the serial port
        /// </summary>
        /// <param name="SerialPortName">Name of serial port to connect on ("COM1", "COM3", etc)</param>
        public NewportMeter(String SerialPortName) : this()
        {
            Open(SerialPortName);
        }

        private void Open(String SerialPortName)
        {
            this.SerialPortName = SerialPortName;
            SerialPort.Open(SerialPortName, 38400, 8, StopBits.One, Parity.None);
            if (SerialPort.IsConnected)
            {
                SerialPort.DataIn += SerialPort_DataIn;
                SerialPort.DataOut += SerialPort_DataOut;
            }
        }

        /// <summary>
        /// Close the serial port, freeing all resources associated with it
        /// </summary>
        public void Close()
        {
            try
            {
                SerialPort.DataIn -= SerialPort_DataIn;
                SerialPort.DataOut -= SerialPort_DataOut;
            }
            catch
            {
                // Ignore errors closing
            }
            finally
            {
                SerialPort.Close();
            }
        }

        #endregion

        #region Instance Variables

        private String SerialPortName = null;
        /// <summary>
        /// The SerialPortName used to initialize this XLDevice instance
        /// </summary>
        public String PortName
        {
            get { return SerialPortName; }
        }

        #endregion

        #region Error Handling

        /// <summary>
        /// Delegate to handle errors communicating with the power meter
        /// </summary>
        /// <param name="Meter">NewportMeter instance generating this event</param>
        /// <param name="ErrorMessage">Error Message</param>
        /// <param name="ErrorCode">Code for error, if known (-1 if unknown)</param>
        public delegate void PowerMeterErrorHandler(NewportMeter<Port> PowerMeter, String ErrorMessage, int ErrorCode);
        event PowerMeterErrorHandler ErrorHandler;

        /// <summary>
        /// Event called when a power meter error occurs.
        /// </summary>
        public event PowerMeterErrorHandler OnPowerMeterError
        {
            add { ErrorHandler += value; }
            remove { ErrorHandler -= value; }
        }

        /// <summary>
        /// Handle an error communicating with the power meter.  Will invoke the PowerMeterError event if
        /// any handler(s) are assigned, or will throw an apporpriate exception if no handler is assigned
        /// </summary>
        private void DoPowerMeterError(String ErrorMessage, int ErrorCode = -1)
        {
            if (ErrorHandler == null)
            {
                if (ErrorCode == -1)
                    throw new NewportMeterCommandException(ErrorMessage);
                else
                    throw new NewportMeterException(ErrorCode, ErrorMessage);
            }
            else
                ErrorHandler.Invoke(this, ErrorMessage, ErrorCode);
        }

        #endregion

        #region Communication Events

        public Boolean GeneratingEvents { get; set; }

        /// <summary>
        /// Event generated whenever data is received from the Meter
        /// The data bytes in this event are entirely unfiltered/unprocessed
        /// </summary>
        public event DataInOutHandler DataReceived;

        /// <summary>
        /// Event generated whenever data is sent to the Meter
        /// The data bytes in this event are exactly as sent to the device
        /// </summary>
        public event DataInOutHandler DataSent;

        #endregion

        #region Base Communication

        static double CommandTimeoutMilliseconds = 400d;

        private Port SerialPort;
        private Queue<Byte> SerialBuffer = new Queue<byte>();

        private Object AtomicSendReceiveLock = new Object();

        // Line ending for XL commands
        static String EndLine = "\r";

        /// <summary>
        /// New data received from serial port; process
        /// </summary>
        /// <param name="DataBytes">Raw data received from serial port</param>
        private void SerialPort_DataIn(ISerialPort Sender, Queue<byte> DataBytes)
        {
            lock (SerialBuffer)
            {
                foreach (byte DataByte in DataBytes)
                    SerialBuffer.Enqueue(DataByte);
            }

            if (GeneratingEvents)
                DataReceived?.Invoke(Sender, DataBytes);
        }

        /// <summary>
        /// Data being sent to the serial port
        /// </summary>
        private void SerialPort_DataOut(ISerialPort sender, Queue<byte> DataBytes)
        {
            if (GeneratingEvents)
                DataSent?.Invoke(sender, DataBytes);
        }

        /// <summary>
        /// Empty the buffer of received data 
        /// </summary>
        private void ClearSerialBuffer()
        {
            lock (SerialBuffer)
            {
                SerialBuffer.Clear();
            }
        }

        /// <summary>
        /// Send raw bytes to the connected device
        /// </summary>
        /// <param name="SendData">Bytes to send</param>
        public void Send(Queue<byte> SendData)
        {
            SerialPort.Send(SendData);
            SerialPort.Flush();
        }

        /// <summary>
        /// Send an ASCII string to the connected device
        /// </summary>
        /// <param name="SendString">String to send to the device.  String is assumed to be ASCII encoding, and
        /// an appropriate line ending is attached to the string before sending.</param>
        public String Send(String SendString)
        {
            String Command = SendString + EndLine;
            Send(new Queue<byte>(Encoding.ASCII.GetBytes(Command)));
            return Command;
        }

        /// <summary>
        /// Read a response to a sent command.  Reads data from the serial port until CRLF has been read 
        /// or a timeout occurs, and returns the read data.
        /// </summary>
        /// <param name="Timeout">Timeout in milliseconds (if nothing has been received in this amount of time, return null)</param>
        /// <returns>Result of last command sent to the device, empty on successful commaand with no response.  Null on timeout.</returns>
        private String GetCommandResponse(double Timeout, String SentCommand, out Boolean CommandEchoed)
        {
            List<Byte> ResponseData = new List<byte>();
            DateTime EndTime = DateTime.Now.AddMilliseconds(Timeout);
            Boolean End = false;
            CommandEchoed = false;
            while (!End)
            {
                int CommandCount = 0;
                byte lastByte = 0;
                lock (SerialBuffer)
                {
                    while (SerialBuffer.Count > 0)
                    {
                        byte Next = SerialBuffer.Dequeue();
                        if ((Next == 0x0A) && (lastByte == 0x0D))
                        {
                            ASCIIEncoding Encoder = new ASCIIEncoding();
                            if (ResponseData.Count > 0)
                            {
                                String Response = Encoder.GetString(ResponseData.ToArray());
                                return Response;
                            }
                        }
                        else
                        {
                            // Strip echoed command characters, if any
                            if ((CommandCount < SentCommand.Length) && (Next == SentCommand[CommandCount]))
                                CommandCount++;
                            else
                                ResponseData.Add(Next);

                            CommandEchoed = (CommandCount >= SentCommand.Length);
                        }
                        lastByte = Next;
                        EndTime = DateTime.Now.AddMilliseconds(Timeout);
                    }
                }

                End = (DateTime.Now >= EndTime);
            }

            return "";
        }

        /// <summary>
        /// Send a command to the connected XL device and wait for a response. Throws an
        /// appropriate RealDCommandException on failure.
        /// </summary>
        /// <param name="Command">Command string to send. If NULL, just continue reading a command response.</param>
        /// <param name="IgnoreErrors">Do not throw exceptions on command error or timeout</param>
        /// <returns>Data received in response to the comamnd</returns>
        private String SendCommand(String Command, Boolean IgnoreErrors = false, Boolean FirstTime = true, Boolean NoEvents = false)
        {
            List<byte> ResponseData = new List<byte>();

            lock (AtomicSendReceiveLock)
            {
                if (NoEvents)
                    GeneratingEvents = false;

                try
                {
                    if (!String.IsNullOrEmpty(Command))
                    {
                        ClearSerialBuffer();
                        Command = Send(Command);
                        System.Threading.Tasks.Task.Delay(150).Wait();
                    }

                    Boolean CommandEchoed;
                    String Response = GetCommandResponse(CommandTimeoutMilliseconds, Command, out CommandEchoed).Trim();
                    if (Response == "")
                    {
                        if ((CommandEchoed) && FirstTime)
                            return SendCommand(Command, IgnoreErrors, false);
                        else if (!IgnoreErrors)
                            DoPowerMeterError("Command Timeout");
                    }
                    return Response;
                }
                finally
                {
                    if (NoEvents)
                        GeneratingEvents = true;
                }
            }
        }

        #endregion

        #region Internal Variables

        public String Make { get; private set; }
        public String Model { get; private set; }
        public String FirmwareVersion { get; private set; }
        public String FirmwareDate { get; private set; }
        public String SerialNumber { get; private set; }

        #endregion

        #region General Commands

        /// <summary>
        /// Parse an identify string returned from the device into component parts
        /// </summary>
        /// <param name="IDString">ID string returned from device, minus any echoed characters</param>
        private void ParseDeviceIDString(String IDString)
        {
            if (!String.IsNullOrEmpty(IDString))
            {
                string[] Parts = IDString.Split(' ');
                SerialNumber = (Parts.Length > 4) ? Parts[4] : "";
                FirmwareDate = (Parts.Length > 3) ? Parts[3] : "";
                FirmwareVersion = ((Parts.Length > 2) && (Parts[2].Length > 0)) ? Parts[2].Substring(1) : "";
                Model = (Parts.Length > 1) ? Parts[1] : "";
                Make = Parts[0];
            }
            else
            {
                SerialNumber = "";
                FirmwareDate = "";
                FirmwareVersion = "";
                Model = "";
                Make = "";
            }
        }

        /// <summary>
        /// Check a command response for an error message from the meter.
        /// These will only be present on errors if Echo is turned on
        /// </summary>
        /// <param name="ResponseString">Response string to check for error</param>
        private void CheckError(String ResponseString)
        {
            if (!String.IsNullOrEmpty(ResponseString))
            {
                string[] Parts = ResponseString.Split(',');
                if (Parts.Length > 1)
                {
                    int ErrorCode = 0;
                    int.TryParse(Parts[0], out ErrorCode);
                    DoPowerMeterError(Parts[1], ErrorCode);
                }
            }
        }

        /// <summary>
        /// Send a command string with no expected response, other than a possible
        /// error message.
        /// </summary>
        /// <param name="Command">Command to send to the meter</param>
        public void SendCommandWithErrorOnlyResponse(String Command)
        {
            CheckError(SendCommand(Command, true));
        }

        /// <summary>
        /// Send a command string with an expected response of a single integer value
        /// (or a possible error message)
        /// </summary>
        /// <param name="Command">Command to send to the meter</param>
        /// <returns>Response from command</returns>
        public int SendCommandWithIntResponse(String Command)
        {
            int Response;
            String ResponseString = SendCommand(Command);
            if (int.TryParse(ResponseString, out Response))
                return Response;
            else
            {
                DoPowerMeterError(ResponseString);
                return 0;
            }
        }

        /// <summary>
        /// Send a command string with an expected response of a single floating-point value
        /// (or a possible error message)
        /// </summary>
        /// <param name="Command">Command to send to the meter</param>
        /// <returns>Response from command</returns>
        public double SendCommandWithRealResponse(String Command, Boolean NoEvents = false)
        {
            double Response;
            String ResponseString = SendCommand(Command, NoEvents, true, NoEvents);
            if (NoEvents && String.IsNullOrEmpty(ResponseString))
                return double.NaN;

            if (double.TryParse(ResponseString, out Response))
                return Response;
            else
            {
                if (NoEvents)
                    return double.NaN;

                DoPowerMeterError(ResponseString);
                return 0;
            }
        }

        /// <summary>
        /// Send a command string with an expected response of a series of floating-point
        /// values seperated by spaces (or a possible error message)
        /// </summary>
        /// <param name="Command">Command to send to the meter</param>
        /// <returns>All responses from the command, in order. Invalid responses are skipped.  May be empty.</returns>
        public List<double> SendCommandWithMultipleRealResponses(String Command)
        {
            String ResponseString = SendCommand(Command);

            List<double> Responses = new List<double>();
            foreach (String subString in ResponseString.Split(' '))
            {
                double Response;
                if (double.TryParse(subString.Trim(), out Response))
                    Responses.Add(Response);
            }
            return Responses;
        }

        /// <summary>
        /// Request the device ID string from the meter, and use it to populate the
        /// Make, Model, Serial Number, and FirmwareVersion/Date properties
        /// </summary>
        /// <returns>Full ID string as returned from theee meter</returns>
        public String GetDeviceID()
        {
            String IDString = SendCommand("*IDN?", true);
            ParseDeviceIDString(IDString);
            return IDString;
        }

        /// <summary>
        /// Enable throwing exceptions if the meter reports an error (out of range, etc) on
        /// an issued command
        /// If enabled, a NewportMeterException will be thrown on any command the meter reports as invalid
        /// </summary>
        public void EnableCommandErrorExceptions()
        {
            SendCommandWithErrorOnlyResponse("ECHO 1");
        }

        /// <summary>
        /// Disable throwing exceptions on errors executing issued commands (out of range, etc)
        /// </summary>
        public void DisableCommandErrorException()
        {
            SendCommandWithErrorOnlyResponse("ECHO 0");
        }

        /// <summary>
        /// Will exceptions be thrown if issued commands result in an error?
        /// If enabled, a NewportMeterException will be thrown on any command the meter reports as invalid
        /// </summary>
        /// <returns>TRUE if exceptions will be thrown, FALSE otherwise</returns>
        public Boolean CommandErrorExceptionsAreEnabled()
        {
            return (SendCommandWithIntResponse("ECHO?") > 0);
        }

        #endregion

        #region Power Meter (PM:) commands

        /// <summary>
        /// Return the current acquisition mode for the detector
        /// </summary>
        /// <returns>Acquisition mode, Unknown if error on determining</returns>
        public AcquisitionMode GetAcquisitionMode()
        {
            int AcqMode = SendCommandWithIntResponse("PM:MODE?");
            switch (AcqMode)
            {
                case 0:
                    return AcquisitionMode.Continuous;
                case 1:
                    return AcquisitionMode.Single;
                case 3:
                    return AcquisitionMode.ContinuousPeakToPeak;
                case 4:
                    return AcquisitionMode.SinglePeakToPeak;
                case 7:
                    return AcquisitionMode.RMS;
            }
            return AcquisitionMode.Unknown;
        }

        /// <summary>
        /// Set the acquisition mode to use
        /// </summary>
        /// <param name="mode">Mode to start using</param>
        public void SetAcquisitionMode(AcquisitionMode mode)
        {
            SendCommandWithErrorOnlyResponse("PM:MODE " + ((int)mode).ToString());
        }

        /// <summary>
        /// Set the unit to be used for measurement readings
        /// </summary>
        /// <param name="Unit">Unit of power measurement</param>
        public void SetPowerUnit(PowerUnit Unit)
        {
            SendCommandWithErrorOnlyResponse("PM:UNIT " + (byte)Unit);
        }

        /// <summary>
        /// Get the unit currently being used for measurement readings
        /// </summary>
        /// <returns>Unit of power measurement currently being used</returns>
        public PowerUnit GetPowerUnit()
        {
            String UnitString = SendCommand("PM:UNIT?");
            PowerUnit Unit;
            if (Enum.TryParse<PowerUnit>(UnitString, out Unit))
                return Unit;
            return PowerUnit.Unknown;
        }

        /// <summary>
        /// Set the wavelength to use when calculating power
        /// </summary>
        /// <param name="Wavelength">Wavelength in nanometers</param>
        public void SetWavelength(int Wavelength)
        {
            SendCommandWithErrorOnlyResponse("PM:Lambda " + Wavelength);
        }

        /// <summary>
        /// Get the wavelength used when calculating power
        /// </summary>
        /// <returns>Wavelength in nanometers</returns>
        public int GetWavelength()
        {
            return SendCommandWithIntResponse("PM:Lambda?");
        }

        /// <summary>
        /// Enable or Disable Automatic ranging on readings
        /// </summary>
        /// <param name="AutoRanging">TRUE if meter should be auto ranging; FALSE if not</param>
        public void SetAutoPowerRanging(Boolean AutoRanging)
        {
            SendCommandWithErrorOnlyResponse("PM:AUTO " + (AutoRanging ? "1" : "0"));
        }

        /// <summary>
        /// Is the power meter currently set to automatic ranging
        /// </summary>
        /// <returns></returns>
        public Boolean GetAutoPowerRanging()
        {
            return (SendCommandWithIntResponse("PM:AUTO?") == 1);
        }

        /// <summary>
        /// Enable or Disable use of attenuator when calculating power
        /// </summary>
        /// <param name="UseAttenuator">TRUE if attenuator should be used in power calibration</param>
        public void SetUseAttenuator(Boolean UseAttenuator)
        {
            SendCommandWithErrorOnlyResponse("PM:ATT " + (UseAttenuator ? "1" : "0"));
        }

        /// <summary>
        /// Calculate power with attenuator?
        /// </summary>
        /// <returns>TRUE if using attenuator, FALSE if calibrating power without attenuator</returns>
        public Boolean GetUseAttenuator()
        {
            return (SendCommandWithIntResponse("PM:ATT?") == 1);
        }

        /// <summary>
        /// Get the attenuator serial number, if found
        /// </summary>
        /// <returns>Serial Number of attenuator, or error string</returns>
        public String GetAttenuatorSerialNumber()
        {
            return SendCommand("PM:ATTSN?");
        }

        /// <summary>
        /// Set the active analog filter
        /// </summary>
        /// <param name="filter">Analog Filter to use</param>
        public void SetAnalogFilter(AnalogFilter filter)
        {
            SendCommandWithErrorOnlyResponse("PM:ANALOGFILTER " + (int)filter);
        }

        /// <summary>
        /// Return the analog filter currently being used
        /// </summary>
        /// <returns>Active analog filter</returns>
        public AnalogFilter GetAnalogFilter()
        {
            return (AnalogFilter)SendCommandWithIntResponse("PM:ANALOGFILTER?");
        }

        /// <summary>
        /// Set the digital filter window size
        /// </summary>
        /// <param name="window">Window size for the digital filter, from 0 - 10000</param>
        public void SetDigitalFilter(int window)
        {
            SendCommandWithErrorOnlyResponse("PM:DIGITALFILTER " + window.ToString());
        }

        /// <summary>
        /// Get the digital filter window size
        /// </summary>
        /// <returns>Window size for the digital filter</returns>
        public int GetDigitalFilter()
        {
            return SendCommandWithIntResponse("PM:DIGITALFILTER?");
        }

        /// <summary>
        /// Get the detector spot size.
        /// </summary>
        /// <returns>Spot size of the detector, in cm2</returns>
        public double GetSpotSize()
        {
            return SendCommandWithRealResponse("PM:SPOTSIZE?");
        }

        /// <summary>
        /// Set the detector spot size
        /// </summary>
        /// <param name="size">Spot size in cm2</param>
        public void SetSpotSize(double size)
        {
            SendCommandWithErrorOnlyResponse("PM:SPOTSIZE " + size.ToString("F4"));
        }

        #endregion

        #region External Trigger ("PM:TRIG:") commands

        /// <summary>
        /// Get the active external trigger edge
        /// </summary>
        /// <returns>Active Edge (Rising or Falling) of the external trigger</returns>
        public TriggerEdge GetExternalTriggerEdge()
        {
            return (TriggerEdge)SendCommandWithIntResponse("PM:TRIG:EDGE?");
        }

        /// <summary>
        /// Set the active external trigger edge 
        /// </summary>
        /// <param name="triggerEdge">Should external trigger activate on rising or falling edge?</param>
        public void SetExternalTriggerEdge(TriggerEdge triggerEdge)
        {
            SendCommandWithErrorOnlyResponse("PM:TRIG:EDGE " + ((int)triggerEdge).ToString());
        }

        /// <summary>
        /// Get the event that starts triggered measurement
        /// </summary>
        /// <returns>Starting Event</returns>
        public TriggerEvent GetTriggerStartEvent()
        {
            return (TriggerEvent)SendCommandWithIntResponse("PM:TRIG:START?");
        }

        /// <summary>
        /// Set the event that starts triggered measurement
        /// </summary>
        /// <param name="triggerEvent">Starting Event</param>
        public void SetTriggerStartEvent(TriggerEvent triggerEvent)
        {
            SendCommandWithErrorOnlyResponse("PM:TRIG:START " + ((int)triggerEvent).ToString());
        }

        /// <summary>
        /// Get the event that stops triggered measurement
        /// </summary>
        /// <returns>Stopping Event</returns>
        public TriggerEvent GetTriggerStopEvent()
        {
            return (TriggerEvent)SendCommandWithIntResponse("PM:TRIG:STOP?");
        }

        /// <summary>
        /// Get the value for the trigger stop event, if the triggerEvent is .MeasuredValue or .Interval
        /// </summary>
        /// <param name="triggerEvent">Trigger stopping event</param>
        /// <returns>Value associated with stopping event; 0d if no asssociated value</returns>
        public double GetTriggerStopValue(TriggerEvent triggerEvent)
        {
            if (triggerEvent == TriggerEvent.MeasuredValue)
                return SendCommandWithRealResponse("PM:TRIG:VALUE?");
            else if (triggerEvent == TriggerEvent.Interval)
                return (double)SendCommandWithIntResponse("PM:TRIG:TIME?");
            return 0d;
        }

        /// <summary>
        /// Set the event that starts triggered measurement
        /// </summary>
        /// <param name="triggerEvent">Starting Event</param>
        /// <param name="triggerValue">Value of stopping condition (if triggerEvent is .MeasuredValue, this indicates a value over which measurement will stop;
        /// if triggerEvent is .Interval, this indicates a number of milliseconds past the trigger start event to stop)</param>
        public void SetTriggerStopEvent(TriggerEvent triggerEvent, double triggerValue = 0d)
        {
            SendCommandWithErrorOnlyResponse("PM:TRIG:STOP " + ((int)triggerEvent).ToString());
            if (triggerEvent == TriggerEvent.MeasuredValue)
                SendCommandWithErrorOnlyResponse("PM:TRIG:VALUE " + triggerValue.ToString("G4"));
            else if (triggerEvent == TriggerEvent.Interval)
                SendCommandWithErrorOnlyResponse("PM:TRIG:TIME" + ((int)(triggerValue)).ToString());
        }

        /// <summary>
        /// Is the system triggered?
        /// </summary>
        /// <returns>TRUE if trigger has been activated and at least one measurement occured; FALSE if system is waiting for trigger</returns>
        public Boolean GetTriggeredState()
        {
            return (SendCommandWithIntResponse("PM:TRIG:STATE?") > 0) ? true : false;
        }

        /// <summary>
        /// Send a software trigger command
        /// </summary>
        public void SendTriggerCommand()
        {
            SendCommandWithErrorOnlyResponse("PM:TRIG:STATE 1");
        }

        /// <summary>
        /// Forece the system to an untriggered state
        /// </summary>
        public void SetUntriggered()
        {
            SendCommandWithErrorOnlyResponse("PM:TRIG:STATE 0");
        }

        /// <summary>
        /// Get the value of the holdoff timer on the trigger.
        /// </summary>
        /// <returns>Delay this many milliseconds before trigger takes effect</returns>
        public double GetTriggerHoldoff()
        {
            return SendCommandWithRealResponse("PM:TRIG:HOLDoff?");
        }

        /// <summary>
        /// Set the trigger holdoff timer
        /// </summary>
        /// <param name="holdoffMilliseconds">Delay this many milliseconds before trigger takes effect</param>
        public void SetTriggerHoldoff(double holdoffMilliseconds)
        {
            SendCommandWithErrorOnlyResponse("PM:TRIG:HOLDoff " + holdoffMilliseconds.ToString("G4"));
        }

        /// <summary>
        /// Get the state of external triggering
        /// </summary>
        /// <returns>Currently active external triggers</returns>
        public ExternalTrigger GetExternalTriggers()
        {
            return (ExternalTrigger)SendCommandWithIntResponse("PM:TRIG:EXTernal?");
        }

        /// <summary>
        /// Enable or Disable external triggering
        /// </summary>
        /// <param name="externalTrigger">Channels to enable external triggering, if any</param>
        public void SetExternalTrigger(ExternalTrigger externalTrigger)
        {
            SendCommandWithErrorOnlyResponse("PM:TRIG:EXTernal " + ((int)externalTrigger).ToString());
        }

        #endregion

        #region Data Store ("PM:DS:") Commands

        /// <summary>
        /// Clear the data store of all data
        /// </summary>
        public void ClearDataStore()
        {
            SendCommandWithErrorOnlyResponse("PM:DS:CLear");
        }

        /// <summary>
        /// Get the number of measurements that have been collected in the data store
        /// </summary>
        /// <returns>Number of measurements</returns>
        /// <seealso cref="GetDataStoreSize"/>
        public int GetDataStoreCount()
        {
            return SendCommandWithIntResponse("PM:DS:Count?");
        }

        /// <summary>
        /// Get the total number of measurements the data store can hold
        /// </summary>
        /// <returns>Maximum number of measurements</returns>
        /// <seealso cref="GetDataStoreCount"/>
        public int GetDataStoreSize()
        {
            return SendCommandWithIntResponse("PM:DS:SIZE?");
        }

        /// <summary>
        /// Set the total number of measurements the data store can hold
        /// </summary>
        /// <param name="Size">Max number of measurements in the data store, 1 to 25000</param>
        /// <remarks>Changing the data store size will clear any data stored in the data store</remarks>
        public void SetDataStoreSize(int Size)
        {
            SendCommandWithErrorOnlyResponse("PM:DS:SIZE " + Size.ToString());
        }

        /// <summary>
        /// Get the interval for storing measurements in the data store
        /// </summary>
        /// <returns>Measurement interval in tenths of a millisecond</returns>
        public int GetDataStoreInterval()
        {
            return SendCommandWithIntResponse("PM:DS:INTerval?");
        }

        /// <summary>
        /// Set the interval for storing measurements in the data store
        /// </summary>
        /// <param name="Interval">Measurement interval in tenths of a milliseconds/param>
        public void SetDataStoreInterval(int Interval)
        {
            SendCommandWithErrorOnlyResponse("PM:DS:INTerval " + Interval.ToString());
        }

        /// <summary>
        /// Check if measurements are currently being stored in the data store
        /// </summary>
        /// <returns>TRUE if currently accumulating measurements in data store, FALSE otherwise</returns>
        public Boolean IsCollectingData()
        {
            return (SendCommandWithIntResponse("PM:DS:ENable?") > 0);
        }

        /// <summary>
        /// Start accumulating measurements in the data store, and continue collecting until
        /// either StopDataCollection() has been called or the full number of measurements
        /// have been collected (Size * Interval milliseconds have passed)
        /// </summary>
        /// <seealso cref="GetDataStoreInterval"/>
        /// <seealso cref="GetDataStoreSize"/>
        public void StartDataCollection()
        {
            SendCommandWithErrorOnlyResponse("PM:DS:ENable 1");
        }

        /// <summary>
        /// Stop accumulating measurements in the data store
        /// </summary>
        public void StopDataCollection()
        {
            SendCommandWithErrorOnlyResponse("PM:DS:ENable 0");
        }

        /// <summary>
        /// Get the currently-set buffer type
        /// </summary>
        /// <returns>Buffer type of the connected power meter</returns>
        public BufferType GetDataStoreBufferType()
        {
            try
            {
                return (BufferType)SendCommandWithIntResponse("PM:DS:BUFfer?");
            }
            catch
            {
                return BufferType.Unknown;
            }
        }

        /// <summary>
        /// Set the buffer type to use for sample acquitition on the attached power meter
        /// </summary>
        /// <param name="bufferType">Buffer type to use (throws expection for Unknown)</param>
        public void SetDataStoreBufferType(BufferType bufferType)
        {
            SendCommandWithErrorOnlyResponse("PM:DS:BUFfer " + ((int)bufferType).ToString());
        }

        #endregion

        #region Power Measurement Commands

        /// <summary>
        /// Return an instantaneous power measurement
        /// </summary>
        /// <returns>Power measurement using the currently set units</returns>
        public double GetPower()
        {
            return SendCommandWithRealResponse("PM:Power?");
        }

        /// <summary>
        /// Return an instantaneous power measurement, don't log power measurement serial commands
        /// </summary>
        /// <returns>Power measurement using the currently set units</returns>
        public double GetPowerInBackground()
        {
            return SendCommandWithRealResponse("PM:Power?", true);
        }

        /// <summary>
        /// Return the mean of all measurements accumulated in the data store
        /// </summary>
        /// <returns>Mean power measurement, in the units set during data collection</returns>
        public double GetMeanPower()
        {
            return SendCommandWithRealResponse("PM:STAT:MEAN?");
        }

        /// <summary>
        /// Set the power measurement correction settings.  Mesaured values are corrected to actual measurements by the formula
        /// Corrected = ((Measured * M1) + Offset) * M2
        /// </summary>
        /// <param name="M1">Multiplier to the measured value</param>
        /// <param name="Offset">Additive offset to the measured value</param>
        /// <param name="M2">Multiplier to the final value</param>
        public void SetCorrection(double M1, double Offset, double M2)
        {
            SendCommandWithErrorOnlyResponse("PM:CORR " + M1.ToString("G4") + "," + Offset.ToString("G4") + "," + M2.ToString("G4"));
        }

        /// <summary>
        /// Get the power measurement correction settings.   Mesaured values are corrected to actual measurements by the formula
        /// Corrected = ((Measured * M1) + Offset) * M2
        /// </summary>
        /// <param name="M1">Multiplier to the measured value</param>
        /// <param name="Offset">Additive offset to the measured value</param>
        /// <param name="M2">Multiplier to the final value</param>
        /// <returns>TRUE if correction settings are set, FALSE if unable to read</returns>
        public Boolean GetCorrection(out double M1, out double Offset, out double M2)
        {
            List<double> Corrections = SendCommandWithMultipleRealResponses("PM:CORR?");
            if (Corrections.Count < 3)
            {
                M1 = 0d;
                Offset = 0d;
                M2 = 0d;
                return false;
            }

            M1 = Corrections[0];
            Offset = Corrections[1];
            M2 = Corrections[2];
            return true;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Check a COM port for the presence of a power meter.
        /// </summary>
        /// <param name="ComPort">COM port name to check</param>
        /// <param name="FailedToOpen">On return, this is TRUE if the COM port failed to open (i.e., if another process had it open), FALSE if COM port opened but doesn't appear to be a power meter</param>
        /// <returns>TRUE if an appropriate meter was found on the COM port specified, FALSE otherwise (FALSE if another process has COM port open)</returns>
        public static Boolean CheckForMeter(String ComPort, out Boolean FailedToOpen)
        {
            FailedToOpen = true;
            try
            {
                if (!String.IsNullOrEmpty(ComPort))
                {
                    using (NewportMeter<Port> Newport = new NewportMeter<Port>(ComPort))
                    {
                        FailedToOpen = false;
                        Newport.SendCommand("", true);
                        Newport.GetDeviceID();
                        if (Newport.Make.Equals("NEWPORT"))
                            return true;
                    }
                }
            }
            catch
            {
                // An exception probably means somebody else has this COM port open, or it is not a 
                // power meter.  In either case, we can't use it.
            }
            finally
            {

            }

            return false;
        }

        /// <summary>
        /// Check all system COM ports for the presence of a power meter
        /// </summary>
        /// <returns>COM port of first found power meter, or NULL if none are found</returns>
        public static String FindCOMPortForMeter(ISerialPortEnumerator Enumerator)
        {
            List<String> FailedCOMPorts = new List<string>();

            foreach (String ComPort in Enumerator.EnumerateSerialPortNames())
            {
                Boolean FailedToOpen;
                if (CheckForMeter(ComPort, out FailedToOpen))
                    return ComPort;

                if (FailedToOpen)
                    FailedCOMPorts.Add(ComPort);
            }

            // If we had some COM ports we couldn't open, wait a while and try again
            if (FailedCOMPorts.Count > 0)
            {
                Random rnd = new Random();
                System.Threading.Thread.Sleep(rnd.Next(500, 1000));
                foreach (String ComPort in FailedCOMPorts)
                {
                    Boolean FailedToOpen;
                    if (CheckForMeter(ComPort, out FailedToOpen))
                        return ComPort;
                }
            }

            return null;
        }

        /// <summary>
        /// Reset the meter to known standard settings:
        /// - DC Continuous Acquisition
        /// - Wavelength 550 nm, Auto Ranging, No Attenuator
        /// - 5 Hz Analog Filter, Digital Filter Window 10000
        /// - Measurement Unit Watts
        /// - No external trigger
        /// - No power measurement correction factors
        /// - Data Store set to Fixed Buffer of 10000 samples with a .1 ms interval
        /// </summary>
        /// <returns>
        /// TRUE if standard settings set; FALSE if unable to for some reason (detector disconnected, etc)
        /// </returns>
        public Boolean SetStandardSettings()
        {
            try
            {
                // Measurement Settings
                SetWavelength(550);
                SetAutoPowerRanging(true);
                SetUseAttenuator(false);
                SetPowerUnit(PowerUnit.Watts);
                SetAnalogFilter(AnalogFilter.FiveHz);
                SetDigitalFilter(10000);
                SetAcquisitionMode(AcquisitionMode.Continuous);
                SetCorrection(1.0, 0.0, 1.0);

                // Trigger Settings
                SetExternalTrigger(ExternalTrigger.None);
                SetTriggerStartEvent(TriggerEvent.None);
                SetTriggerStopEvent(TriggerEvent.None);
                SetTriggerHoldoff(0d);

                // Set Data Store
                SetDataStoreBufferType(BufferType.Fixed);
                SetDataStoreInterval(1);
                SetDataStoreSize(10000);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Returns a string representing a given power reading with appropriate SI unit prefix
        /// Note: The exact SI unit splitting differs from that shown on the meter face
        /// </summary>
        /// <param name="Power">Power Reading</param>
        /// <param name="Unit">Base Units ("W", etc)</param>
        /// <returns>String with Power expressed with appropriate SI units of BaseUnit</returns>
        public String PowerAsSIString(double Power, String Unit)
        {
            char[] incPrefixes = new[] { 'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };
            char[] decPrefixes = new[] { 'm', '\u03bc', 'n', 'p', 'f', 'a', 'z', 'y' };

            if ((Power == 0) || (Power == double.MinValue) || (Power == double.MaxValue) || double.IsInfinity(Power) || double.IsNaN(Power))
                return Power.ToString() + " " + Unit;

            int degree = (int)Math.Floor(Math.Log10(Math.Abs(Power)) / 3);
            double scaled = Power * Math.Pow(1000, -degree);

            if ((degree > 8) || (degree < -8) || (degree == 0))
                return Power.ToString("G") + " " + Unit;

            char prefix = (Math.Sign(degree) == 1) ? incPrefixes[degree - 1] : decPrefixes[-degree - 1];
            return scaled.ToString("F1") + " " + prefix + Unit;
        }

        #endregion

        #region IDisposable Pattern

        ~NewportMeter()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            try
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            finally
            {
                // Call base Dispose(), if needed
                // base.Dispose();
            }
        }

        public void Dispose(Boolean FreeManagedObjects)
        {
            Close();
            SerialPort.Dispose();
            if (FreeManagedObjects)
            {

            }
        }

        #endregion

    }
}
