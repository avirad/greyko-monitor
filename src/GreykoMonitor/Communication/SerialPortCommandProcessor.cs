using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreykoMonitor.Communication.Commands;
using System.IO.Ports;

namespace GreykoMonitor.Communication
{
    public class SerialPortCommandProcessor : ICommandProcessor
    {
        private SerialPort _serialPort;

        public SerialPortCommandProcessor(string portName)
        {
            _serialPort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
        }

        public void ProcessCommand(ICommand command)
        {
            _serialPort.Open();

            byte[] request = command.GetRequest();
            _serialPort.Write(request, 0, request.Length);

            System.Threading.Thread.Sleep(100);

            var response = _serialPort.ReadExisting();
            command.ProcessResponse(Encoding.ASCII.GetBytes(response));

            _serialPort.Close();
        }
    }
}
