namespace PKSerialCommunicationWindowsTester
{
    partial class frmNewportMeterTester
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpComLog = new System.Windows.Forms.GroupBox();
            this.txtSerialLog = new System.Windows.Forms.RichTextBox();
            this.txtSendString = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.btnRefreshPorts = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.txtDeviceSerial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeviceFirmware = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeviceModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefreshDeviceInfo = new System.Windows.Forms.Button();
            this.txtDeviceType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSetUnit = new System.Windows.Forms.Button();
            this.cmbPower = new System.Windows.Forms.ComboBox();
            this.grpWavelength = new System.Windows.Forms.GroupBox();
            this.txtWavelength = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSetWavelength = new System.Windows.Forms.Button();
            this.btnRefreshWavelength = new System.Windows.Forms.Button();
            this.grpDataStore = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnClearDataStore = new System.Windows.Forms.Button();
            this.cmbBufferType = new System.Windows.Forms.ComboBox();
            this.txtDataStoreCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGetDataStoreCount = new System.Windows.Forms.Button();
            this.btnCheckMeasuring = new System.Windows.Forms.Button();
            this.chkIsMeasuring = new System.Windows.Forms.CheckBox();
            this.btnStopMeasuring = new System.Windows.Forms.Button();
            this.btnStartMeasuring = new System.Windows.Forms.Button();
            this.txtDataStoreInterval = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSetDataStoreInterval = new System.Windows.Forms.Button();
            this.txtDataStoreSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSetDataStoreSize = new System.Windows.Forms.Button();
            this.btnRefreshDataStore = new System.Windows.Forms.Button();
            this.grpPowerReading = new System.Windows.Forms.GroupBox();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.btnGetAveragePower = new System.Windows.Forms.Button();
            this.btnGetPower = new System.Windows.Forms.Button();
            this.chkAutoRange = new System.Windows.Forms.CheckBox();
            this.chkUseAttenuator = new System.Windows.Forms.CheckBox();
            this.txtAttenuator = new System.Windows.Forms.TextBox();
            this.cmbAnalogFilter = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDigitalFilter = new System.Windows.Forms.TextBox();
            this.btnSetDigitalFilter = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbAcqMode = new System.Windows.Forms.ComboBox();
            this.txtSpotSize = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSetSpotSize = new System.Windows.Forms.Button();
            this.grpTrigger = new System.Windows.Forms.GroupBox();
            this.btnRefreshTriggers = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbTriggerEdge = new System.Windows.Forms.ComboBox();
            this.txtTriggerHoldoff = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbTriggerStart = new System.Windows.Forms.ComboBox();
            this.cmbTriggerStop = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTriggerStopValue = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnCheckTrigger = new System.Windows.Forms.Button();
            this.chkTriggered = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbExternalTrigger = new System.Windows.Forms.ComboBox();
            this.btnSetTriggerHoldoff = new System.Windows.Forms.Button();
            this.grpCorrection = new System.Windows.Forms.GroupBox();
            this.txtM1 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtM2 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.btnSetCorrection = new System.Windows.Forms.Button();
            this.btnGetCorrection = new System.Windows.Forms.Button();
            this.grpComLog.SuspendLayout();
            this.grpConnection.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.grpWavelength.SuspendLayout();
            this.grpDataStore.SuspendLayout();
            this.grpPowerReading.SuspendLayout();
            this.grpTrigger.SuspendLayout();
            this.grpCorrection.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpComLog
            // 
            this.grpComLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpComLog.Controls.Add(this.txtSerialLog);
            this.grpComLog.Controls.Add(this.txtSendString);
            this.grpComLog.Controls.Add(this.btnSend);
            this.grpComLog.Enabled = false;
            this.grpComLog.Location = new System.Drawing.Point(11, 139);
            this.grpComLog.Margin = new System.Windows.Forms.Padding(2);
            this.grpComLog.Name = "grpComLog";
            this.grpComLog.Padding = new System.Windows.Forms.Padding(2);
            this.grpComLog.Size = new System.Drawing.Size(459, 542);
            this.grpComLog.TabIndex = 6;
            this.grpComLog.TabStop = false;
            this.grpComLog.Text = "Raw Communication";
            // 
            // txtSerialLog
            // 
            this.txtSerialLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerialLog.Location = new System.Drawing.Point(6, 47);
            this.txtSerialLog.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerialLog.Name = "txtSerialLog";
            this.txtSerialLog.Size = new System.Drawing.Size(445, 491);
            this.txtSerialLog.TabIndex = 5;
            this.txtSerialLog.Text = "";
            // 
            // txtSendString
            // 
            this.txtSendString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendString.Location = new System.Drawing.Point(6, 22);
            this.txtSendString.Margin = new System.Windows.Forms.Padding(2);
            this.txtSendString.Name = "txtSendString";
            this.txtSendString.Size = new System.Drawing.Size(362, 20);
            this.txtSendString.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(376, 21);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(72, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.btnRefreshPorts);
            this.grpConnection.Controls.Add(this.btnConnect);
            this.grpConnection.Controls.Add(this.label1);
            this.grpConnection.Controls.Add(this.cmbSerialPort);
            this.grpConnection.Location = new System.Drawing.Point(11, 11);
            this.grpConnection.Margin = new System.Windows.Forms.Padding(2);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Padding = new System.Windows.Forms.Padding(2);
            this.grpConnection.Size = new System.Drawing.Size(153, 123);
            this.grpConnection.TabIndex = 7;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Connection";
            // 
            // btnRefreshPorts
            // 
            this.btnRefreshPorts.Location = new System.Drawing.Point(76, -1);
            this.btnRefreshPorts.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshPorts.Name = "btnRefreshPorts";
            this.btnRefreshPorts.Size = new System.Drawing.Size(70, 19);
            this.btnRefreshPorts.TabIndex = 3;
            this.btnRefreshPorts.Text = "Refresh Ports";
            this.btnRefreshPorts.UseVisualStyleBackColor = true;
            this.btnRefreshPorts.Click += new System.EventHandler(this.btnRefreshPorts_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(38, 86);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(72, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM Port";
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(12, 46);
            this.cmbSerialPort.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.Size = new System.Drawing.Size(136, 21);
            this.cmbSerialPort.TabIndex = 0;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.txtDeviceSerial);
            this.grpInfo.Controls.Add(this.label5);
            this.grpInfo.Controls.Add(this.txtDeviceFirmware);
            this.grpInfo.Controls.Add(this.label4);
            this.grpInfo.Controls.Add(this.txtDeviceModel);
            this.grpInfo.Controls.Add(this.label3);
            this.grpInfo.Controls.Add(this.btnRefreshDeviceInfo);
            this.grpInfo.Controls.Add(this.txtDeviceType);
            this.grpInfo.Controls.Add(this.label2);
            this.grpInfo.Enabled = false;
            this.grpInfo.Location = new System.Drawing.Point(168, 11);
            this.grpInfo.Margin = new System.Windows.Forms.Padding(2);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Padding = new System.Windows.Forms.Padding(2);
            this.grpInfo.Size = new System.Drawing.Size(180, 123);
            this.grpInfo.TabIndex = 8;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Device Info";
            // 
            // txtDeviceSerial
            // 
            this.txtDeviceSerial.Location = new System.Drawing.Point(84, 93);
            this.txtDeviceSerial.Margin = new System.Windows.Forms.Padding(2);
            this.txtDeviceSerial.Name = "txtDeviceSerial";
            this.txtDeviceSerial.ReadOnly = true;
            this.txtDeviceSerial.Size = new System.Drawing.Size(89, 20);
            this.txtDeviceSerial.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 96);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Serial #";
            // 
            // txtDeviceFirmware
            // 
            this.txtDeviceFirmware.Location = new System.Drawing.Point(84, 69);
            this.txtDeviceFirmware.Margin = new System.Windows.Forms.Padding(2);
            this.txtDeviceFirmware.Name = "txtDeviceFirmware";
            this.txtDeviceFirmware.ReadOnly = true;
            this.txtDeviceFirmware.Size = new System.Drawing.Size(89, 20);
            this.txtDeviceFirmware.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Firmware";
            // 
            // txtDeviceModel
            // 
            this.txtDeviceModel.Location = new System.Drawing.Point(84, 46);
            this.txtDeviceModel.Margin = new System.Windows.Forms.Padding(2);
            this.txtDeviceModel.Name = "txtDeviceModel";
            this.txtDeviceModel.ReadOnly = true;
            this.txtDeviceModel.Size = new System.Drawing.Size(89, 20);
            this.txtDeviceModel.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Model";
            // 
            // btnRefreshDeviceInfo
            // 
            this.btnRefreshDeviceInfo.Location = new System.Drawing.Point(103, -1);
            this.btnRefreshDeviceInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshDeviceInfo.Name = "btnRefreshDeviceInfo";
            this.btnRefreshDeviceInfo.Size = new System.Drawing.Size(70, 19);
            this.btnRefreshDeviceInfo.TabIndex = 4;
            this.btnRefreshDeviceInfo.Text = "Refresh Device Info";
            this.btnRefreshDeviceInfo.UseVisualStyleBackColor = true;
            this.btnRefreshDeviceInfo.Click += new System.EventHandler(this.btnRefreshDeviceInfo_Click);
            // 
            // txtDeviceType
            // 
            this.txtDeviceType.Location = new System.Drawing.Point(84, 22);
            this.txtDeviceType.Margin = new System.Windows.Forms.Padding(2);
            this.txtDeviceType.Name = "txtDeviceType";
            this.txtDeviceType.ReadOnly = true;
            this.txtDeviceType.Size = new System.Drawing.Size(89, 20);
            this.txtDeviceType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Device Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 70);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Power Unit";
            // 
            // btnSetUnit
            // 
            this.btnSetUnit.Location = new System.Drawing.Point(215, 65);
            this.btnSetUnit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetUnit.Name = "btnSetUnit";
            this.btnSetUnit.Size = new System.Drawing.Size(52, 23);
            this.btnSetUnit.TabIndex = 7;
            this.btnSetUnit.Text = "Set Units";
            this.btnSetUnit.UseVisualStyleBackColor = true;
            this.btnSetUnit.Click += new System.EventHandler(this.btnSetUnit_Click);
            // 
            // cmbPower
            // 
            this.cmbPower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPower.FormattingEnabled = true;
            this.cmbPower.Items.AddRange(new object[] {
            "Unknown",
            "Amps",
            "Watts",
            "Watts/cm2",
            "DBm"});
            this.cmbPower.Location = new System.Drawing.Point(123, 67);
            this.cmbPower.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPower.Name = "cmbPower";
            this.cmbPower.Size = new System.Drawing.Size(83, 21);
            this.cmbPower.TabIndex = 6;
            // 
            // grpWavelength
            // 
            this.grpWavelength.Controls.Add(this.btnSetSpotSize);
            this.grpWavelength.Controls.Add(this.txtSpotSize);
            this.grpWavelength.Controls.Add(this.label16);
            this.grpWavelength.Controls.Add(this.label15);
            this.grpWavelength.Controls.Add(this.cmbAcqMode);
            this.grpWavelength.Controls.Add(this.btnSetDigitalFilter);
            this.grpWavelength.Controls.Add(this.txtDigitalFilter);
            this.grpWavelength.Controls.Add(this.label14);
            this.grpWavelength.Controls.Add(this.label13);
            this.grpWavelength.Controls.Add(this.cmbAnalogFilter);
            this.grpWavelength.Controls.Add(this.txtAttenuator);
            this.grpWavelength.Controls.Add(this.chkUseAttenuator);
            this.grpWavelength.Controls.Add(this.chkAutoRange);
            this.grpWavelength.Controls.Add(this.label6);
            this.grpWavelength.Controls.Add(this.btnSetUnit);
            this.grpWavelength.Controls.Add(this.txtWavelength);
            this.grpWavelength.Controls.Add(this.cmbPower);
            this.grpWavelength.Controls.Add(this.label7);
            this.grpWavelength.Controls.Add(this.btnSetWavelength);
            this.grpWavelength.Controls.Add(this.btnRefreshWavelength);
            this.grpWavelength.Location = new System.Drawing.Point(353, 12);
            this.grpWavelength.Name = "grpWavelength";
            this.grpWavelength.Size = new System.Drawing.Size(502, 122);
            this.grpWavelength.TabIndex = 10;
            this.grpWavelength.TabStop = false;
            this.grpWavelength.Text = "Measurement Settings";
            // 
            // txtWavelength
            // 
            this.txtWavelength.Location = new System.Drawing.Point(123, 41);
            this.txtWavelength.Margin = new System.Windows.Forms.Padding(2);
            this.txtWavelength.Name = "txtWavelength";
            this.txtWavelength.Size = new System.Drawing.Size(83, 20);
            this.txtWavelength.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Wavelength (nm)";
            // 
            // btnSetWavelength
            // 
            this.btnSetWavelength.Location = new System.Drawing.Point(215, 40);
            this.btnSetWavelength.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetWavelength.Name = "btnSetWavelength";
            this.btnSetWavelength.Size = new System.Drawing.Size(52, 23);
            this.btnSetWavelength.TabIndex = 7;
            this.btnSetWavelength.Text = "Set Wavelength";
            this.btnSetWavelength.UseVisualStyleBackColor = true;
            this.btnSetWavelength.Click += new System.EventHandler(this.btnSetWavelength_Click);
            // 
            // btnRefreshWavelength
            // 
            this.btnRefreshWavelength.Location = new System.Drawing.Point(417, 0);
            this.btnRefreshWavelength.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshWavelength.Name = "btnRefreshWavelength";
            this.btnRefreshWavelength.Size = new System.Drawing.Size(59, 19);
            this.btnRefreshWavelength.TabIndex = 5;
            this.btnRefreshWavelength.Text = "Refresh Wavelength";
            this.btnRefreshWavelength.UseVisualStyleBackColor = true;
            this.btnRefreshWavelength.Click += new System.EventHandler(this.btnRefreshWavelength_Click);
            // 
            // grpDataStore
            // 
            this.grpDataStore.Controls.Add(this.label12);
            this.grpDataStore.Controls.Add(this.btnClearDataStore);
            this.grpDataStore.Controls.Add(this.cmbBufferType);
            this.grpDataStore.Controls.Add(this.txtDataStoreCount);
            this.grpDataStore.Controls.Add(this.label10);
            this.grpDataStore.Controls.Add(this.btnGetDataStoreCount);
            this.grpDataStore.Controls.Add(this.btnCheckMeasuring);
            this.grpDataStore.Controls.Add(this.chkIsMeasuring);
            this.grpDataStore.Controls.Add(this.btnStopMeasuring);
            this.grpDataStore.Controls.Add(this.btnStartMeasuring);
            this.grpDataStore.Controls.Add(this.txtDataStoreInterval);
            this.grpDataStore.Controls.Add(this.label9);
            this.grpDataStore.Controls.Add(this.btnSetDataStoreInterval);
            this.grpDataStore.Controls.Add(this.txtDataStoreSize);
            this.grpDataStore.Controls.Add(this.label8);
            this.grpDataStore.Controls.Add(this.btnSetDataStoreSize);
            this.grpDataStore.Controls.Add(this.btnRefreshDataStore);
            this.grpDataStore.Location = new System.Drawing.Point(476, 140);
            this.grpDataStore.Name = "grpDataStore";
            this.grpDataStore.Size = new System.Drawing.Size(379, 242);
            this.grpDataStore.TabIndex = 12;
            this.grpDataStore.TabStop = false;
            this.grpDataStore.Text = "Data Store";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 25);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Buffer Type";
            // 
            // btnClearDataStore
            // 
            this.btnClearDataStore.Location = new System.Drawing.Point(259, 199);
            this.btnClearDataStore.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearDataStore.Name = "btnClearDataStore";
            this.btnClearDataStore.Size = new System.Drawing.Size(66, 23);
            this.btnClearDataStore.TabIndex = 22;
            this.btnClearDataStore.Text = "Clear";
            this.btnClearDataStore.UseVisualStyleBackColor = true;
            this.btnClearDataStore.Click += new System.EventHandler(this.btnClearDataStore_Click);
            // 
            // cmbBufferType
            // 
            this.cmbBufferType.FormattingEnabled = true;
            this.cmbBufferType.Items.AddRange(new object[] {
            "(Unknown)",
            "Fixed",
            "Continuous"});
            this.cmbBufferType.Location = new System.Drawing.Point(15, 40);
            this.cmbBufferType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbBufferType.Name = "cmbBufferType";
            this.cmbBufferType.Size = new System.Drawing.Size(122, 21);
            this.cmbBufferType.TabIndex = 4;
            this.cmbBufferType.SelectedIndexChanged += new System.EventHandler(this.cmbBufferType_SelectedIndexChanged);
            // 
            // txtDataStoreCount
            // 
            this.txtDataStoreCount.Location = new System.Drawing.Point(97, 198);
            this.txtDataStoreCount.Margin = new System.Windows.Forms.Padding(2);
            this.txtDataStoreCount.Name = "txtDataStoreCount";
            this.txtDataStoreCount.ReadOnly = true;
            this.txtDataStoreCount.Size = new System.Drawing.Size(123, 20);
            this.txtDataStoreCount.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(94, 182);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Measurements Collected";
            // 
            // btnGetDataStoreCount
            // 
            this.btnGetDataStoreCount.Location = new System.Drawing.Point(259, 172);
            this.btnGetDataStoreCount.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetDataStoreCount.Name = "btnGetDataStoreCount";
            this.btnGetDataStoreCount.Size = new System.Drawing.Size(66, 23);
            this.btnGetDataStoreCount.TabIndex = 19;
            this.btnGetDataStoreCount.Text = "Count";
            this.btnGetDataStoreCount.UseVisualStyleBackColor = true;
            this.btnGetDataStoreCount.Click += new System.EventHandler(this.btnGetDataStoreCount_Click);
            // 
            // btnCheckMeasuring
            // 
            this.btnCheckMeasuring.Location = new System.Drawing.Point(259, 40);
            this.btnCheckMeasuring.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckMeasuring.Name = "btnCheckMeasuring";
            this.btnCheckMeasuring.Size = new System.Drawing.Size(110, 19);
            this.btnCheckMeasuring.TabIndex = 18;
            this.btnCheckMeasuring.Text = "Check";
            this.btnCheckMeasuring.UseVisualStyleBackColor = true;
            this.btnCheckMeasuring.Click += new System.EventHandler(this.btnCheckMeasuring_Click);
            // 
            // chkIsMeasuring
            // 
            this.chkIsMeasuring.AutoSize = true;
            this.chkIsMeasuring.Enabled = false;
            this.chkIsMeasuring.Location = new System.Drawing.Point(164, 40);
            this.chkIsMeasuring.Name = "chkIsMeasuring";
            this.chkIsMeasuring.Size = new System.Drawing.Size(81, 17);
            this.chkIsMeasuring.TabIndex = 17;
            this.chkIsMeasuring.Text = "Measuring?";
            this.chkIsMeasuring.UseVisualStyleBackColor = true;
            // 
            // btnStopMeasuring
            // 
            this.btnStopMeasuring.Location = new System.Drawing.Point(260, 122);
            this.btnStopMeasuring.Margin = new System.Windows.Forms.Padding(2);
            this.btnStopMeasuring.Name = "btnStopMeasuring";
            this.btnStopMeasuring.Size = new System.Drawing.Size(109, 23);
            this.btnStopMeasuring.TabIndex = 16;
            this.btnStopMeasuring.Text = "Stop Measuring";
            this.btnStopMeasuring.UseVisualStyleBackColor = true;
            this.btnStopMeasuring.Click += new System.EventHandler(this.btnStopMeasuring_Click);
            // 
            // btnStartMeasuring
            // 
            this.btnStartMeasuring.Location = new System.Drawing.Point(260, 88);
            this.btnStartMeasuring.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartMeasuring.Name = "btnStartMeasuring";
            this.btnStartMeasuring.Size = new System.Drawing.Size(109, 23);
            this.btnStartMeasuring.TabIndex = 15;
            this.btnStartMeasuring.Text = "Start Measuring";
            this.btnStartMeasuring.UseVisualStyleBackColor = true;
            this.btnStartMeasuring.Click += new System.EventHandler(this.btnStartMeasuring_Click);
            // 
            // txtDataStoreInterval
            // 
            this.txtDataStoreInterval.Location = new System.Drawing.Point(14, 138);
            this.txtDataStoreInterval.Margin = new System.Windows.Forms.Padding(2);
            this.txtDataStoreInterval.Name = "txtDataStoreInterval";
            this.txtDataStoreInterval.Size = new System.Drawing.Size(123, 20);
            this.txtDataStoreInterval.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 122);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Interval (tenths of ms)";
            // 
            // btnSetDataStoreInterval
            // 
            this.btnSetDataStoreInterval.Location = new System.Drawing.Point(157, 136);
            this.btnSetDataStoreInterval.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetDataStoreInterval.Name = "btnSetDataStoreInterval";
            this.btnSetDataStoreInterval.Size = new System.Drawing.Size(66, 23);
            this.btnSetDataStoreInterval.TabIndex = 12;
            this.btnSetDataStoreInterval.Text = "Set Interval";
            this.btnSetDataStoreInterval.UseVisualStyleBackColor = true;
            this.btnSetDataStoreInterval.Click += new System.EventHandler(this.btnSetDataStoreInterval_Click);
            // 
            // txtDataStoreSize
            // 
            this.txtDataStoreSize.Location = new System.Drawing.Point(15, 91);
            this.txtDataStoreSize.Margin = new System.Windows.Forms.Padding(2);
            this.txtDataStoreSize.Name = "txtDataStoreSize";
            this.txtDataStoreSize.Size = new System.Drawing.Size(123, 20);
            this.txtDataStoreSize.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 75);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Size (# of Measurements)";
            // 
            // btnSetDataStoreSize
            // 
            this.btnSetDataStoreSize.Location = new System.Drawing.Point(158, 89);
            this.btnSetDataStoreSize.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetDataStoreSize.Name = "btnSetDataStoreSize";
            this.btnSetDataStoreSize.Size = new System.Drawing.Size(66, 23);
            this.btnSetDataStoreSize.TabIndex = 7;
            this.btnSetDataStoreSize.Text = "Set Size";
            this.btnSetDataStoreSize.UseVisualStyleBackColor = true;
            this.btnSetDataStoreSize.Click += new System.EventHandler(this.btnSetDataStoreSize_Click);
            // 
            // btnRefreshDataStore
            // 
            this.btnRefreshDataStore.Location = new System.Drawing.Point(294, 2);
            this.btnRefreshDataStore.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshDataStore.Name = "btnRefreshDataStore";
            this.btnRefreshDataStore.Size = new System.Drawing.Size(59, 19);
            this.btnRefreshDataStore.TabIndex = 5;
            this.btnRefreshDataStore.Text = "Refresh Wavelength";
            this.btnRefreshDataStore.UseVisualStyleBackColor = true;
            this.btnRefreshDataStore.Click += new System.EventHandler(this.btnRefreshDataStore_Click);
            // 
            // grpPowerReading
            // 
            this.grpPowerReading.Controls.Add(this.txtPower);
            this.grpPowerReading.Controls.Add(this.btnGetAveragePower);
            this.grpPowerReading.Controls.Add(this.btnGetPower);
            this.grpPowerReading.Location = new System.Drawing.Point(476, 600);
            this.grpPowerReading.Name = "grpPowerReading";
            this.grpPowerReading.Size = new System.Drawing.Size(380, 81);
            this.grpPowerReading.TabIndex = 13;
            this.grpPowerReading.TabStop = false;
            this.grpPowerReading.Text = "Power Readings";
            // 
            // txtPower
            // 
            this.txtPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPower.Location = new System.Drawing.Point(7, 26);
            this.txtPower.Margin = new System.Windows.Forms.Padding(2);
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(185, 38);
            this.txtPower.TabIndex = 22;
            // 
            // btnGetAveragePower
            // 
            this.btnGetAveragePower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetAveragePower.Location = new System.Drawing.Point(290, 27);
            this.btnGetAveragePower.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetAveragePower.Name = "btnGetAveragePower";
            this.btnGetAveragePower.Size = new System.Drawing.Size(81, 38);
            this.btnGetAveragePower.TabIndex = 21;
            this.btnGetAveragePower.Text = "Get Average Reading";
            this.btnGetAveragePower.UseVisualStyleBackColor = true;
            this.btnGetAveragePower.Click += new System.EventHandler(this.btnGetAveragePower_Click);
            // 
            // btnGetPower
            // 
            this.btnGetPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetPower.Location = new System.Drawing.Point(199, 27);
            this.btnGetPower.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetPower.Name = "btnGetPower";
            this.btnGetPower.Size = new System.Drawing.Size(85, 38);
            this.btnGetPower.TabIndex = 20;
            this.btnGetPower.Text = "Get Reading";
            this.btnGetPower.UseVisualStyleBackColor = true;
            this.btnGetPower.Click += new System.EventHandler(this.btnGetPower_Click);
            // 
            // chkAutoRange
            // 
            this.chkAutoRange.AutoSize = true;
            this.chkAutoRange.Location = new System.Drawing.Point(291, 21);
            this.chkAutoRange.Name = "chkAutoRange";
            this.chkAutoRange.Size = new System.Drawing.Size(116, 17);
            this.chkAutoRange.TabIndex = 23;
            this.chkAutoRange.Text = "Automatic Ranging";
            this.chkAutoRange.UseVisualStyleBackColor = true;
            this.chkAutoRange.CheckedChanged += new System.EventHandler(this.chkAutoRange_CheckedChanged);
            // 
            // chkUseAttenuator
            // 
            this.chkUseAttenuator.AutoSize = true;
            this.chkUseAttenuator.Location = new System.Drawing.Point(291, 43);
            this.chkUseAttenuator.Name = "chkUseAttenuator";
            this.chkUseAttenuator.Size = new System.Drawing.Size(97, 17);
            this.chkUseAttenuator.TabIndex = 24;
            this.chkUseAttenuator.Text = "Use Attenuator";
            this.chkUseAttenuator.UseVisualStyleBackColor = true;
            this.chkUseAttenuator.CheckedChanged += new System.EventHandler(this.chkUseAttenuator_CheckedChanged);
            // 
            // txtAttenuator
            // 
            this.txtAttenuator.Location = new System.Drawing.Point(393, 42);
            this.txtAttenuator.Margin = new System.Windows.Forms.Padding(2);
            this.txtAttenuator.Name = "txtAttenuator";
            this.txtAttenuator.ReadOnly = true;
            this.txtAttenuator.Size = new System.Drawing.Size(83, 20);
            this.txtAttenuator.TabIndex = 23;
            // 
            // cmbAnalogFilter
            // 
            this.cmbAnalogFilter.FormattingEnabled = true;
            this.cmbAnalogFilter.Items.AddRange(new object[] {
            "None",
            "12.5 kHz",
            "1 kHz",
            "5 Hz"});
            this.cmbAnalogFilter.Location = new System.Drawing.Point(353, 68);
            this.cmbAnalogFilter.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAnalogFilter.Name = "cmbAnalogFilter";
            this.cmbAnalogFilter.Size = new System.Drawing.Size(84, 21);
            this.cmbAnalogFilter.TabIndex = 23;
            this.cmbAnalogFilter.SelectedIndexChanged += new System.EventHandler(this.cmbAnalogFilter_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(284, 71);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Analog Filter";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(288, 97);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Digital Filter";
            // 
            // txtDigitalFilter
            // 
            this.txtDigitalFilter.Location = new System.Drawing.Point(353, 92);
            this.txtDigitalFilter.Margin = new System.Windows.Forms.Padding(2);
            this.txtDigitalFilter.Name = "txtDigitalFilter";
            this.txtDigitalFilter.Size = new System.Drawing.Size(83, 20);
            this.txtDigitalFilter.TabIndex = 23;
            // 
            // btnSetDigitalFilter
            // 
            this.btnSetDigitalFilter.Location = new System.Drawing.Point(215, 92);
            this.btnSetDigitalFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetDigitalFilter.Name = "btnSetDigitalFilter";
            this.btnSetDigitalFilter.Size = new System.Drawing.Size(52, 23);
            this.btnSetDigitalFilter.TabIndex = 23;
            this.btnSetDigitalFilter.Text = "Set Interval";
            this.btnSetDigitalFilter.UseVisualStyleBackColor = true;
            this.btnSetDigitalFilter.Click += new System.EventHandler(this.btnSetDigitalFilter_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 19);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Acquisition Mode";
            // 
            // cmbAcqMode
            // 
            this.cmbAcqMode.FormattingEnabled = true;
            this.cmbAcqMode.Items.AddRange(new object[] {
            "DC Continuous",
            "DC Single",
            "Peak-to-peak Continuous",
            "Peak-to-peak Single",
            "RMS"});
            this.cmbAcqMode.Location = new System.Drawing.Point(123, 16);
            this.cmbAcqMode.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAcqMode.Name = "cmbAcqMode";
            this.cmbAcqMode.Size = new System.Drawing.Size(144, 21);
            this.cmbAcqMode.TabIndex = 27;
            this.cmbAcqMode.SelectedIndexChanged += new System.EventHandler(this.cmbAcqMode_SelectedIndexChanged);
            // 
            // txtSpotSize
            // 
            this.txtSpotSize.Location = new System.Drawing.Point(123, 94);
            this.txtSpotSize.Margin = new System.Windows.Forms.Padding(2);
            this.txtSpotSize.Name = "txtSpotSize";
            this.txtSpotSize.Size = new System.Drawing.Size(83, 20);
            this.txtSpotSize.TabIndex = 28;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(25, 97);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 13);
            this.label16.TabIndex = 29;
            this.label16.Text = "Spot Size (cm2)";
            // 
            // btnSetSpotSize
            // 
            this.btnSetSpotSize.Location = new System.Drawing.Point(440, 90);
            this.btnSetSpotSize.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetSpotSize.Name = "btnSetSpotSize";
            this.btnSetSpotSize.Size = new System.Drawing.Size(52, 23);
            this.btnSetSpotSize.TabIndex = 30;
            this.btnSetSpotSize.Text = "Set Interval";
            this.btnSetSpotSize.UseVisualStyleBackColor = true;
            this.btnSetSpotSize.Click += new System.EventHandler(this.btnSetSpotSize_Click);
            // 
            // grpTrigger
            // 
            this.grpTrigger.Controls.Add(this.btnSetTriggerHoldoff);
            this.grpTrigger.Controls.Add(this.label21);
            this.grpTrigger.Controls.Add(this.cmbExternalTrigger);
            this.grpTrigger.Controls.Add(this.btnCheckTrigger);
            this.grpTrigger.Controls.Add(this.chkTriggered);
            this.grpTrigger.Controls.Add(this.txtTriggerStopValue);
            this.grpTrigger.Controls.Add(this.label20);
            this.grpTrigger.Controls.Add(this.label19);
            this.grpTrigger.Controls.Add(this.cmbTriggerStop);
            this.grpTrigger.Controls.Add(this.label18);
            this.grpTrigger.Controls.Add(this.cmbTriggerStart);
            this.grpTrigger.Controls.Add(this.txtTriggerHoldoff);
            this.grpTrigger.Controls.Add(this.label17);
            this.grpTrigger.Controls.Add(this.label11);
            this.grpTrigger.Controls.Add(this.cmbTriggerEdge);
            this.grpTrigger.Controls.Add(this.btnRefreshTriggers);
            this.grpTrigger.Enabled = false;
            this.grpTrigger.Location = new System.Drawing.Point(476, 389);
            this.grpTrigger.Name = "grpTrigger";
            this.grpTrigger.Size = new System.Drawing.Size(380, 135);
            this.grpTrigger.TabIndex = 14;
            this.grpTrigger.TabStop = false;
            this.grpTrigger.Text = "Triggers";
            // 
            // btnRefreshTriggers
            // 
            this.btnRefreshTriggers.Location = new System.Drawing.Point(294, -2);
            this.btnRefreshTriggers.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshTriggers.Name = "btnRefreshTriggers";
            this.btnRefreshTriggers.Size = new System.Drawing.Size(59, 19);
            this.btnRefreshTriggers.TabIndex = 6;
            this.btnRefreshTriggers.Text = "Refresh Triggers";
            this.btnRefreshTriggers.UseVisualStyleBackColor = true;
            this.btnRefreshTriggers.Click += new System.EventHandler(this.btnRefreshTriggers_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 55);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Trigger Edge";
            // 
            // cmbTriggerEdge
            // 
            this.cmbTriggerEdge.FormattingEnabled = true;
            this.cmbTriggerEdge.Items.AddRange(new object[] {
            "Falling",
            "Rising"});
            this.cmbTriggerEdge.Location = new System.Drawing.Point(84, 49);
            this.cmbTriggerEdge.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTriggerEdge.Name = "cmbTriggerEdge";
            this.cmbTriggerEdge.Size = new System.Drawing.Size(82, 21);
            this.cmbTriggerEdge.TabIndex = 7;
            this.cmbTriggerEdge.SelectedIndexChanged += new System.EventHandler(this.cmbTriggerEdge_SelectedIndexChanged);
            // 
            // txtTriggerHoldoff
            // 
            this.txtTriggerHoldoff.Location = new System.Drawing.Point(239, 24);
            this.txtTriggerHoldoff.Margin = new System.Windows.Forms.Padding(2);
            this.txtTriggerHoldoff.Name = "txtTriggerHoldoff";
            this.txtTriggerHoldoff.Size = new System.Drawing.Size(76, 20);
            this.txtTriggerHoldoff.TabIndex = 16;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(172, 27);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "Holdoff (ms)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(202, 52);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 13);
            this.label18.TabIndex = 18;
            this.label18.Text = "Triggered Start";
            // 
            // cmbTriggerStart
            // 
            this.cmbTriggerStart.FormattingEnabled = true;
            this.cmbTriggerStart.Items.AddRange(new object[] {
            "None",
            "Trigger In",
            "Soft Key",
            "Command"});
            this.cmbTriggerStart.Location = new System.Drawing.Point(283, 49);
            this.cmbTriggerStart.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTriggerStart.Name = "cmbTriggerStart";
            this.cmbTriggerStart.Size = new System.Drawing.Size(86, 21);
            this.cmbTriggerStart.TabIndex = 17;
            this.cmbTriggerStart.SelectedIndexChanged += new System.EventHandler(this.cmbTriggerStart_SelectedIndexChanged);
            // 
            // cmbTriggerStop
            // 
            this.cmbTriggerStop.FormattingEnabled = true;
            this.cmbTriggerStop.Items.AddRange(new object[] {
            "None",
            "Trigger In",
            "Soft Key",
            "Command",
            "Measured Value",
            "Time Interval"});
            this.cmbTriggerStop.Location = new System.Drawing.Point(283, 79);
            this.cmbTriggerStop.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTriggerStop.Name = "cmbTriggerStop";
            this.cmbTriggerStop.Size = new System.Drawing.Size(86, 21);
            this.cmbTriggerStop.TabIndex = 19;
            this.cmbTriggerStop.SelectedIndexChanged += new System.EventHandler(this.cmbTriggerStop_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(195, 82);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 13);
            this.label19.TabIndex = 20;
            this.label19.Text = "Triggered Stop";
            // 
            // txtTriggerStopValue
            // 
            this.txtTriggerStopValue.Location = new System.Drawing.Point(283, 104);
            this.txtTriggerStopValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtTriggerStopValue.Name = "txtTriggerStopValue";
            this.txtTriggerStopValue.Size = new System.Drawing.Size(86, 20);
            this.txtTriggerStopValue.TabIndex = 22;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(184, 107);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(95, 13);
            this.label20.TabIndex = 21;
            this.label20.Text = "Trigger Stop Value";
            // 
            // btnCheckTrigger
            // 
            this.btnCheckTrigger.Location = new System.Drawing.Point(44, 101);
            this.btnCheckTrigger.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckTrigger.Name = "btnCheckTrigger";
            this.btnCheckTrigger.Size = new System.Drawing.Size(110, 19);
            this.btnCheckTrigger.TabIndex = 24;
            this.btnCheckTrigger.Text = "Check";
            this.btnCheckTrigger.UseVisualStyleBackColor = true;
            this.btnCheckTrigger.Click += new System.EventHandler(this.btnCheckTrigger_Click);
            // 
            // chkTriggered
            // 
            this.chkTriggered.AutoSize = true;
            this.chkTriggered.Enabled = false;
            this.chkTriggered.Location = new System.Drawing.Point(60, 83);
            this.chkTriggered.Name = "chkTriggered";
            this.chkTriggered.Size = new System.Drawing.Size(77, 17);
            this.chkTriggered.TabIndex = 23;
            this.chkTriggered.Text = "Triggered?";
            this.chkTriggered.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 27);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 13);
            this.label21.TabIndex = 26;
            this.label21.Text = "Trigger";
            // 
            // cmbExternalTrigger
            // 
            this.cmbExternalTrigger.FormattingEnabled = true;
            this.cmbExternalTrigger.Items.AddRange(new object[] {
            "None",
            "Channel A",
            "Channel B",
            "Channel A B"});
            this.cmbExternalTrigger.Location = new System.Drawing.Point(60, 24);
            this.cmbExternalTrigger.Margin = new System.Windows.Forms.Padding(2);
            this.cmbExternalTrigger.Name = "cmbExternalTrigger";
            this.cmbExternalTrigger.Size = new System.Drawing.Size(106, 21);
            this.cmbExternalTrigger.TabIndex = 25;
            this.cmbExternalTrigger.SelectedIndexChanged += new System.EventHandler(this.cmbExternalTrigger_SelectedIndexChanged);
            // 
            // btnSetTriggerHoldoff
            // 
            this.btnSetTriggerHoldoff.Location = new System.Drawing.Point(319, 21);
            this.btnSetTriggerHoldoff.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetTriggerHoldoff.Name = "btnSetTriggerHoldoff";
            this.btnSetTriggerHoldoff.Size = new System.Drawing.Size(52, 23);
            this.btnSetTriggerHoldoff.TabIndex = 27;
            this.btnSetTriggerHoldoff.Text = "Set Holdoff";
            this.btnSetTriggerHoldoff.UseVisualStyleBackColor = true;
            this.btnSetTriggerHoldoff.Click += new System.EventHandler(this.btnSetTriggerHoldoff_Click);
            // 
            // grpCorrection
            // 
            this.grpCorrection.Controls.Add(this.btnGetCorrection);
            this.grpCorrection.Controls.Add(this.btnSetCorrection);
            this.grpCorrection.Controls.Add(this.label25);
            this.grpCorrection.Controls.Add(this.txtM2);
            this.grpCorrection.Controls.Add(this.label24);
            this.grpCorrection.Controls.Add(this.txtOffset);
            this.grpCorrection.Controls.Add(this.label23);
            this.grpCorrection.Controls.Add(this.txtM1);
            this.grpCorrection.Controls.Add(this.label22);
            this.grpCorrection.Enabled = false;
            this.grpCorrection.Location = new System.Drawing.Point(476, 527);
            this.grpCorrection.Name = "grpCorrection";
            this.grpCorrection.Size = new System.Drawing.Size(380, 67);
            this.grpCorrection.TabIndex = 15;
            this.grpCorrection.TabStop = false;
            this.grpCorrection.Text = "Correction";
            // 
            // txtM1
            // 
            this.txtM1.Location = new System.Drawing.Point(44, 42);
            this.txtM1.Margin = new System.Windows.Forms.Padding(2);
            this.txtM1.Name = "txtM1";
            this.txtM1.Size = new System.Drawing.Size(60, 20);
            this.txtM1.TabIndex = 24;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(18, 45);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(22, 13);
            this.label22.TabIndex = 23;
            this.label22.Text = "M1";
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(155, 42);
            this.txtOffset.Margin = new System.Windows.Forms.Padding(2);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(60, 20);
            this.txtOffset.TabIndex = 26;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(116, 45);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 25;
            this.label23.Text = "Offset";
            // 
            // txtM2
            // 
            this.txtM2.Location = new System.Drawing.Point(253, 42);
            this.txtM2.Margin = new System.Windows.Forms.Padding(2);
            this.txtM2.Name = "txtM2";
            this.txtM2.Size = new System.Drawing.Size(60, 20);
            this.txtM2.TabIndex = 28;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(227, 45);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(22, 13);
            this.label24.TabIndex = 27;
            this.label24.Text = "M2";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(58, 18);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(214, 13);
            this.label25.TabIndex = 29;
            this.label25.Text = "Corrected = ((Measured * M1) + Offset) * M2";
            // 
            // btnSetCorrection
            // 
            this.btnSetCorrection.Location = new System.Drawing.Point(317, 39);
            this.btnSetCorrection.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetCorrection.Name = "btnSetCorrection";
            this.btnSetCorrection.Size = new System.Drawing.Size(52, 23);
            this.btnSetCorrection.TabIndex = 30;
            this.btnSetCorrection.Text = "Set Correction";
            this.btnSetCorrection.UseVisualStyleBackColor = true;
            this.btnSetCorrection.Click += new System.EventHandler(this.btnSetCorrection_Click);
            // 
            // btnGetCorrection
            // 
            this.btnGetCorrection.Location = new System.Drawing.Point(317, 10);
            this.btnGetCorrection.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetCorrection.Name = "btnGetCorrection";
            this.btnGetCorrection.Size = new System.Drawing.Size(52, 23);
            this.btnGetCorrection.TabIndex = 31;
            this.btnGetCorrection.Text = "Get Correction";
            this.btnGetCorrection.UseVisualStyleBackColor = true;
            this.btnGetCorrection.Click += new System.EventHandler(this.btnGetCorrection_Click);
            // 
            // frmNewportMeterTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 692);
            this.Controls.Add(this.grpCorrection);
            this.Controls.Add(this.grpTrigger);
            this.Controls.Add(this.grpPowerReading);
            this.Controls.Add(this.grpDataStore);
            this.Controls.Add(this.grpWavelength);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.grpConnection);
            this.Controls.Add(this.grpComLog);
            this.Name = "frmNewportMeterTester";
            this.Text = "Newport Power Meter Communication Tester";
            this.Shown += new System.EventHandler(this.frmNewportMeterTester_Shown);
            this.grpComLog.ResumeLayout(false);
            this.grpComLog.PerformLayout();
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.grpWavelength.ResumeLayout(false);
            this.grpWavelength.PerformLayout();
            this.grpDataStore.ResumeLayout(false);
            this.grpDataStore.PerformLayout();
            this.grpPowerReading.ResumeLayout(false);
            this.grpPowerReading.PerformLayout();
            this.grpTrigger.ResumeLayout(false);
            this.grpTrigger.PerformLayout();
            this.grpCorrection.ResumeLayout(false);
            this.grpCorrection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpComLog;
        private System.Windows.Forms.RichTextBox txtSerialLog;
        private System.Windows.Forms.TextBox txtSendString;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Button btnRefreshPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSerialPort;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Button btnRefreshDeviceInfo;
        private System.Windows.Forms.TextBox txtDeviceType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDeviceSerial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeviceFirmware;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDeviceModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSetUnit;
        private System.Windows.Forms.ComboBox cmbPower;
        private System.Windows.Forms.GroupBox grpWavelength;
        private System.Windows.Forms.TextBox txtWavelength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSetWavelength;
        private System.Windows.Forms.Button btnRefreshWavelength;
        private System.Windows.Forms.GroupBox grpDataStore;
        private System.Windows.Forms.TextBox txtDataStoreInterval;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSetDataStoreInterval;
        private System.Windows.Forms.TextBox txtDataStoreSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSetDataStoreSize;
        private System.Windows.Forms.Button btnRefreshDataStore;
        private System.Windows.Forms.Button btnCheckMeasuring;
        private System.Windows.Forms.CheckBox chkIsMeasuring;
        private System.Windows.Forms.Button btnStopMeasuring;
        private System.Windows.Forms.Button btnStartMeasuring;
        private System.Windows.Forms.TextBox txtDataStoreCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGetDataStoreCount;
        private System.Windows.Forms.Button btnClearDataStore;
        private System.Windows.Forms.GroupBox grpPowerReading;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.Button btnGetAveragePower;
        private System.Windows.Forms.Button btnGetPower;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbBufferType;
        private System.Windows.Forms.CheckBox chkAutoRange;
        private System.Windows.Forms.CheckBox chkUseAttenuator;
        private System.Windows.Forms.TextBox txtAttenuator;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbAnalogFilter;
        private System.Windows.Forms.Button btnSetDigitalFilter;
        private System.Windows.Forms.TextBox txtDigitalFilter;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbAcqMode;
        private System.Windows.Forms.Button btnSetSpotSize;
        private System.Windows.Forms.TextBox txtSpotSize;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox grpTrigger;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbTriggerStop;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbTriggerStart;
        private System.Windows.Forms.TextBox txtTriggerHoldoff;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbTriggerEdge;
        private System.Windows.Forms.Button btnRefreshTriggers;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbExternalTrigger;
        private System.Windows.Forms.Button btnCheckTrigger;
        private System.Windows.Forms.CheckBox chkTriggered;
        private System.Windows.Forms.TextBox txtTriggerStopValue;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnSetTriggerHoldoff;
        private System.Windows.Forms.GroupBox grpCorrection;
        private System.Windows.Forms.Button btnGetCorrection;
        private System.Windows.Forms.Button btnSetCorrection;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtM2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtM1;
        private System.Windows.Forms.Label label22;

    }
}