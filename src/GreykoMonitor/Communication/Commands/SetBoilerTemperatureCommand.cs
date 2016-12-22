using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreykoMonitor.Communication.Commands
{
    public class SetBoilerTemperatureCommand : CommandBase, ICommand
    {
        protected override byte _commandId { get; set; } = 0x07;
        protected override byte[] _requestData { get; set; }
        protected override byte[] _responseData { get; set; }
        protected byte _boilerTemperature;

        public SetBoilerTemperatureCommand(byte boilerTemperature)
        {
            _boilerTemperature = boilerTemperature;
        }

        public override byte[] GetRequestData()
        {
            _requestData = new byte[] { _boilerTemperature };

            return base.GetRequestData();
        }

        public override void ProcessResponseData(byte[] response)
        {
            throw new NotImplementedException();
        }
    }
}
