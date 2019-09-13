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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestNewport_Click(object sender, EventArgs e)
        {
            frmNewportMeterTester tester = new frmNewportMeterTester();
            tester.ShowDialog();
        }
    }
}
