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
                lblSwVer.Text = ((GeneralInformationResponse)response).SwVer;
                lblDate.Text = $"{((GeneralInformationResponse)response).Date.ToShortDateString()} {((GeneralInformationResponse)response).Date.ToShortTimeString()}";
                lblState.Text = ((GeneralInformationResponse)response).State.ToString();
                lblStatus.Text = ((GeneralInformationResponse)response).Status.ToString();
                lblTset.Text = $"{((GeneralInformationResponse)response).Tset} °C";
                lblTboiler.Text = $"{((GeneralInformationResponse)response).Tboiler} °C";
                lblFlame.Text = ((GeneralInformationResponse)response).Flame.ToString();
                lblThermostat.Text = ((GeneralInformationResponse)response).ThermostatStop ? "STOP" : "NORMAL";
                lblCHPump.Text = ((GeneralInformationResponse)response).CHPump ? "ON" : "OFF";
                lblHeater.Text = ((GeneralInformationResponse)response).Heater ? "ON" : "OFF";
            }
            else
            {
                // error
            }
        }
    }
}
