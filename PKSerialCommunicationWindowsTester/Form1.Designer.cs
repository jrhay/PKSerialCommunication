namespace PKSerialCommunicationWindowsTester
{
    partial class Form1
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
            this.btnTestNewport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestNewport
            // 
            this.btnTestNewport.Location = new System.Drawing.Point(36, 24);
            this.btnTestNewport.Name = "btnTestNewport";
            this.btnTestNewport.Size = new System.Drawing.Size(145, 41);
            this.btnTestNewport.TabIndex = 0;
            this.btnTestNewport.Text = "Test Newport Power Meter Communication...";
            this.btnTestNewport.UseVisualStyleBackColor = true;
            this.btnTestNewport.Click += new System.EventHandler(this.btnTestNewport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 102);
            this.ControlBox = false;
            this.Controls.Add(this.btnTestNewport);
            this.Name = "Form1";
            this.Text = "PKSerialCommunication Tester";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestNewport;
    }
}

