using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreykoMonitor.Communication.Commands;
using System.IO.Ports;
using GreykoMonitor.Communication.Entities;

namespace GreykoMonitor.Communication
{
    public class SerialPortCommandProcessor : ICommandProcessor
    {
        private SerialPort _serialPort;

        public SerialPortCommandProcessor(string portName)
        {
            _serialPort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
        }

        public IResponse ProcessCommand(ICommand command)
        {
            _serialPort.Open();

            byte[] requestData = command.GetRequestData();
            _serialPort.Write(requestData, 0, requestData.Length);

            System.Threading.Thread.Sleep(50);

            string responseData = _serialPort.ReadExisting();
            IResponse response = command.ProcessResponseData(Encoding.ASCII.GetBytes(responseData));

            _serialPort.Close();

            return response;
        }
    }
}
