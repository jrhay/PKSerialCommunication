using NewportPowerMeterCommunicationFramework;
using NewportPowerMeterCommunicationFramework.DataTypes;
using NewportPowerMeterCommunicationFramework.Exceptions;
using SerialCommunicationFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PKSerialCommunicationWindowsTester
{
    public partial class frmNewportMeterTester : Form
    {
        NewportMeter<WindowsSerialPort> Newport = null;

        public frmNewportMeterTester()
        {
            InitializeComponent();
        }

        private void frmNewportMeterTester_Shown(object sender, EventArgs e)
        {
            InitPorts();
        }

        public void InitPorts()
        {
            ISerialPortEnumerator Enumerator = new WindowsSerialPortEnumerator();
            cmbSerialPort.Items.Clear();
            cmbSerialPort.Items.AddRange(Enumerator.EnumerateSerialPortNames().ToArray());
        }

        private void btnRefreshPorts_Click(object sender, EventArgs e)
        {
            InitPorts();
        }

        private void SetConnected(Boolean IsConnected)
        {
            grpComLog.Enabled = IsConnected;
            grpInfo.Enabled = IsConnected;
            grpWavelength.Enabled = IsConnected;
            grpDataStore.Enabled = IsConnected;
            grpPowerReading.Enabled = IsConnected;
            grpTrigger.Enabled = IsConnected;
            grpCorrection.Enabled = IsConnected;
        }

        private void Disconnect()
        {
            if (Newport != null)
            {
                try
                {
                    Newport.DataReceived -= Newport_DataReceived;
                    Newport.DataSent -= Newport_DataSent;
                }
                finally
                {
                    Newport.Close();
                    Newport.Dispose();
                    Newport = null;
                }
            }

            SetConnected(false);
            ClearDeviceInfo();
            cmbSerialPort.Enabled = true;
            btnConnect.Text = "Connect";
        }

        String ConnectError = null;
        private Boolean TryConnect(String ComPort)
        {
            ConnectError = null;

            try
            {
                Disconnect();

                btnConnect.Text = "Connecting...";
                if (!String.IsNullOrEmpty(ComPort))
                {
                    txtSerialLog.Clear();
                    Newport = new NewportMeter<WindowsSerialPort>(ComPort);
                    Newport.DataReceived += Newport_DataReceived;
                    Newport.DataSent += Newport_DataSent;
                    cmbSerialPort.Enabled = false;
                }

                GetDeviceInfo();
                if (Newport.Make.Equals("NEWPORT"))
                {
                    btnConnect.Text = "Disconnect";
                    SetConnected(true);
                    return true;
                }
            }
            catch (Exception e)
            {
                ConnectError = e.Message;
            }

            Disconnect();
            return false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;

            if (Newport != null)
                Disconnect();
            else
            {
                if (cmbSerialPort.SelectedItem != null)
                {
                    String ComPort = cmbSerialPort.SelectedItem.ToString();
                    if (!TryConnect(ComPort))
                        MessageBox.Show("Error attempting to connect to Newport device: " + ConnectError, "Command Error or Timeout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (String ComPort in cmbSerialPort.Items)
                    {
                        cmbSerialPort.Text = ComPort;
                        if (TryConnect(ComPort))
                        {
                            btnConnect.Enabled = true;
                            return;
                        }
                    }
                }
            }

            btnConnect.Enabled = true;
        }

        private void AppendSerialLog(String text, Color color)
        {
            txtSerialLog.SelectionStart = txtSerialLog.TextLength;
            txtSerialLog.SelectionLength = 0;
            txtSerialLog.SelectionColor = color;

            txtSerialLog.AppendText(text);
            txtSerialLog.SelectionColor = txtSerialLog.ForeColor;
            txtSerialLog.ScrollToCaret();
        }

        private void Newport_DataReceived(object sender, IEnumerable<byte> DataBytes)
        {
            if (txtSerialLog.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate () { Newport_DataReceived(sender, DataBytes); }));
            }
            else
            {
                AppendSerialLog(Encoding.ASCII.GetString(DataBytes.ToArray()), Color.Black);
            }
        }

        private void Newport_DataSent(object sender, IEnumerable<byte> DataBytes)
        {
            if (txtSerialLog.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate () { Newport_DataSent(sender, DataBytes); }));
            }
            else
            {
                AppendSerialLog(Encoding.ASCII.GetString(DataBytes.ToArray()), Color.Green);
            }
        }

        private void GetDeviceInfo()
        {
            Newport.GetDeviceID();
            txtDeviceType.Text = Newport.Make;
            txtDeviceModel.Text = Newport.Model;
            txtDeviceFirmware.Text = Newport.FirmwareVersion;
            txtDeviceSerial.Text = Newport.SerialNumber;
        }

        private void ClearDeviceInfo()
        {
            txtDeviceType.Text = null;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSendString.Text))
                Newport.Send(txtSendString.Text);
        }

        private void btnRefreshDeviceInfo_Click(object sender, EventArgs e)
        {
            GetDeviceInfo();
        }

        private void btnSetUnit_Click(object sender, EventArgs e)
        {
            PowerUnit Unit = PowerUnit.Unknown;
            if (cmbPower.Text.Equals("Amps"))
                Unit = PowerUnit.Amperes;
            else if (cmbPower.Text.Equals("DBm"))
                Unit = PowerUnit.DecibalMilliwattts;
            else if (cmbPower.Text.Equals("Watts"))
                Unit = PowerUnit.Watts;
            else if (cmbPower.Text.Equals("Watts/cm2"))
                Unit = PowerUnit.WattsPerSquareCentimeter;

            try
            {
                Newport.SetPowerUnit(Unit);
            }
            catch (NewportMeterException ex)
            {
                MessageBox.Show(ex.ErrorCode.ToString() + ": " + ex.Message, "Can not set power units", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshUnits_Click(object sender, EventArgs e)
        {
            PowerUnit Unit = Newport.GetPowerUnit();
            switch (Unit)
            {
                case PowerUnit.Amperes:
                    cmbPower.Text = "Amps";
                    break;
                case PowerUnit.DecibalMilliwattts:
                    cmbPower.Text = "DBm";
                    break;
                case PowerUnit.Watts:
                    cmbPower.Text = "Watts";
                    break;
                case PowerUnit.WattsPerSquareCentimeter:
                    cmbPower.Text = "Watts/cm2";
                    break;
                default:
                    cmbPower.Text = "Unknown";
                    break;
            }
        }

        private void ShowAcqMode()
        {
            AcquisitionMode Mode = Newport.GetAcquisitionMode();
            switch (Mode)
            {
                case AcquisitionMode.Continuous:
                    cmbAcqMode.SelectedIndex = 0;
                    break;
                case AcquisitionMode.Single:
                    cmbAcqMode.SelectedIndex = 1;
                    break;
                case AcquisitionMode.ContinuousPeakToPeak:
                    cmbAcqMode.SelectedIndex = 2;
                    break;
                case AcquisitionMode.SinglePeakToPeak:
                    cmbAcqMode.SelectedIndex = 3;
                    break;
                case AcquisitionMode.RMS:
                    cmbAcqMode.SelectedIndex = 4;
                    break;
                default:
                    cmbAcqMode.SelectedIndex = -1;
                    break;
            }
        }

        private void btnRefreshWavelength_Click(object sender, EventArgs e)
        {
            btnRefreshUnits_Click(sender, e);
            txtWavelength.Text = Newport.GetWavelength().ToString();
            chkAutoRange.Checked = Newport.GetAutoPowerRanging();
            chkUseAttenuator.Checked = Newport.GetUseAttenuator();
            txtAttenuator.Text = Newport.GetAttenuatorSerialNumber();
            cmbAnalogFilter.SelectedIndex = (int)Newport.GetAnalogFilter();
            txtDigitalFilter.Text = Newport.GetDigitalFilter().ToString();
            txtSpotSize.Text = Newport.GetSpotSize().ToString("G4");
            ShowAcqMode();
        }

        private void btnSetWavelength_Click(object sender, EventArgs e)
        {
            try
            {
                int Wavelength;
                if (int.TryParse(txtWavelength.Text, out Wavelength))
                    Newport.SetWavelength(Wavelength);
                else
                    MessageBox.Show("Please enter valid wavelength");
            }
            catch (NewportMeterException ex)
            {
                MessageBox.Show(ex.ErrorCode.ToString() + ": " + ex.Message, "Can not set power units", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshDataStore_Click(object sender, EventArgs e)
        {
            txtDataStoreSize.Text = Newport.GetDataStoreSize().ToString();
            txtDataStoreInterval.Text = Newport.GetDataStoreInterval().ToString();
            cmbBufferType.SelectedIndex = (int)Newport.GetDataStoreBufferType() + 1;
        }

        private void btnSetDataStoreSize_Click(object sender, EventArgs e)
        {
            int Size;
            if (int.TryParse(txtDataStoreSize.Text, out Size))
                Newport.SetDataStoreSize(Size);
            else
                MessageBox.Show("Please enter valid size");
        }

        private void btnSetDataStoreInterval_Click(object sender, EventArgs e)
        {
            int Interval;
            if (int.TryParse(txtDataStoreInterval.Text, out Interval))
                Newport.SetDataStoreInterval(Interval);
            else
                MessageBox.Show("Please enter valid interval");
        }

        private void btnCheckMeasuring_Click(object sender, EventArgs e)
        {
            chkIsMeasuring.Checked = Newport.IsCollectingData();
        }

        private void btnStartMeasuring_Click(object sender, EventArgs e)
        {
            Newport.StartDataCollection();
            btnCheckMeasuring_Click(null, null);
        }

        private void btnStopMeasuring_Click(object sender, EventArgs e)
        {
            Newport.StopDataCollection();
            btnCheckMeasuring_Click(null, null);
        }

        private void btnGetDataStoreCount_Click(object sender, EventArgs e)
        {
            txtDataStoreCount.Text = Newport.GetDataStoreCount().ToString();
        }

        private void btnClearDataStore_Click(object sender, EventArgs e)
        {
            Newport.ClearDataStore();
            btnGetDataStoreCount_Click(null, null);
        }

        private void btnGetPower_Click(object sender, EventArgs e)
        {
            txtPower.Text = Newport.GetPower().ToString();
        }

        private void btnGetAveragePower_Click(object sender, EventArgs e)
        {
            txtPower.Text = Newport.GetMeanPower().ToString();
        }

        private void cmbBufferType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BufferType bufferType = (BufferType)(cmbBufferType.SelectedIndex - 1);
            Newport.SetDataStoreBufferType(bufferType);
        }

        private void chkAutoRange_CheckedChanged(object sender, EventArgs e)
        {
            Newport.SetAutoPowerRanging(chkAutoRange.Checked);
        }

        private void chkUseAttenuator_CheckedChanged(object sender, EventArgs e)
        {
            Newport.SetUseAttenuator(chkUseAttenuator.Checked);
        }

        private void cmbAnalogFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            AnalogFilter filter = (AnalogFilter)cmbAnalogFilter.SelectedIndex;
            Newport.SetAnalogFilter(filter);
        }

        private void btnSetDigitalFilter_Click(object sender, EventArgs e)
        {
            int Window;
            if (int.TryParse(txtDigitalFilter.Text, out Window))
                Newport.SetDigitalFilter(Window);
            else
                MessageBox.Show("Please enter valid filter window");
        }

        private void cmbAcqMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbAcqMode.SelectedIndex)
            {
                case 0:
                    Newport.SetAcquisitionMode(AcquisitionMode.Continuous);
                    break;
                case 1:
                    Newport.SetAcquisitionMode(AcquisitionMode.Single);
                    break;
                case 2:
                    Newport.SetAcquisitionMode(AcquisitionMode.ContinuousPeakToPeak);
                    break;
                case 3:
                    Newport.SetAcquisitionMode(AcquisitionMode.SinglePeakToPeak);
                    break;
                case 4:
                    Newport.SetAcquisitionMode(AcquisitionMode.RMS);
                    break;
            }
        }

        private void btnSetSpotSize_Click(object sender, EventArgs e)
        {
            double SpotSize;
            if (double.TryParse(txtSpotSize.Text, out SpotSize))
                Newport.SetSpotSize(SpotSize);
            else
                MessageBox.Show("Please enter a valid spot size in cm2");
        }

        private void btnRefreshTriggers_Click(object sender, EventArgs e)
        {
            cmbExternalTrigger.SelectedIndex = (int)Newport.GetExternalTriggers();
            cmbTriggerEdge.SelectedIndex = (int)Newport.GetExternalTriggerEdge();
            chkTriggered.Checked = Newport.GetTriggeredState();
            txtTriggerHoldoff.Text = Newport.GetTriggerHoldoff().ToString();
            cmbTriggerStart.SelectedIndex = (int)Newport.GetTriggerStartEvent();
            TriggerEvent StopEvent = Newport.GetTriggerStopEvent();
            cmbTriggerStop.SelectedIndex = (int)StopEvent;
            txtTriggerStopValue.Text = Newport.GetTriggerStopValue(StopEvent).ToString();
        }

        private void btnCheckTrigger_Click(object sender, EventArgs e)
        {
            chkTriggered.Checked = Newport.GetTriggeredState();
        }

        private void btnSetTriggerHoldoff_Click(object sender, EventArgs e)
        {
            double Holdoff = 0;
            if (!double.TryParse(txtTriggerHoldoff.Text, out Holdoff))
                MessageBox.Show("Please enter a valid trigger holdoff value");
            else
                Newport.SetTriggerHoldoff(Holdoff);
        }

        private void cmbExternalTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExternalTrigger triggerState = (ExternalTrigger)cmbExternalTrigger.SelectedIndex;
            Newport.SetExternalTrigger(triggerState);
        }

        private void cmbTriggerEdge_SelectedIndexChanged(object sender, EventArgs e)
        {
            TriggerEdge edge = (TriggerEdge)cmbTriggerEdge.SelectedIndex;
            Newport.SetExternalTriggerEdge(edge);
        }

        private void cmbTriggerStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            TriggerEvent trigger = (TriggerEvent)cmbTriggerStart.SelectedIndex;
            Newport.SetTriggerStartEvent(trigger);
        }

        private void cmbTriggerStop_SelectedIndexChanged(object sender, EventArgs e)
        {
            TriggerEvent StopEvent = (TriggerEvent)cmbTriggerStop.SelectedIndex;
            if ((StopEvent == TriggerEvent.MeasuredValue) || (StopEvent == TriggerEvent.Interval))
            {
                double StopValue = 0d;
                if (!double.TryParse(txtTriggerStopValue.Text, out StopValue))
                    MessageBox.Show("Please enter a valid trigger stop value");
                else
                    Newport.SetTriggerStopEvent(StopEvent, StopValue);
            }
            else
                Newport.SetTriggerStopEvent(StopEvent);
        }

        private void btnGetCorrection_Click(object sender, EventArgs e)
        {
            double M1, Offset, M2;
            if (!Newport.GetCorrection(out M1, out Offset, out M2))
                MessageBox.Show("Unable to read power correction values from meter");
            txtM1.Text = M1.ToString("G4");
            txtOffset.Text = Offset.ToString("G4");
            txtM2.Text = M2.ToString("G4");
        }

        private void btnSetCorrection_Click(object sender, EventArgs e)
        {
            double M1, Offset, M2;

            if (!double.TryParse(txtM1.Text, out M1))
            {
                MessageBox.Show("Please enter a valid value for M1");
                return;
            }
            if (!double.TryParse(txtOffset.Text, out Offset))
            {
                MessageBox.Show("Please enter a valid value for Offset");
                return;
            }
            if (!double.TryParse(txtM2.Text, out M2))
            {
                MessageBox.Show("Please enter a valid value for M2");
                return;
            }
            Newport.SetCorrection(M1, Offset, M2);
        }

    }
}
