using GreykoMonitor.Communication;
using GreykoMonitor.Communication.Commands;
using GreykoMonitor.Communication.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreykoMonitor
{
    public partial class MainForm : Form
    {
        private GreykoMonitor _greykoMonitor;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            SerialPort.GetPortNames().ToList()
                .ForEach(sp => cbSerialPort.Items.Add(sp));

            if (cbSerialPort.Items.Count > 0)
            {
                cbSerialPort.SelectedIndex = 0;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // get burner status
            _greykoMonitor = new GreykoMonitor(new SerialPortCommandProcessor(cbSerialPort.SelectedItem.ToString()));

            IResponse response = _greykoMonitor.GetGeneralInformation();
            if (response is GeneralInformationResponse)
            {

            }
            else
            {
                // error
            }
        }
    }
}
