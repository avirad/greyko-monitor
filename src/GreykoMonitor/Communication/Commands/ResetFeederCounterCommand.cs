using GreykoMonitor.Communication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreykoMonitor.Communication.Commands
{
    public class ResetFeederCounterCommand : CommandBase, ICommand
    {
        protected override byte _commandId { get; set; } = 0x09;
        protected override byte[] _requestData { get; set; }
        protected override byte[] _responseData { get; set; }

        public ResetFeederCounterCommand()
        {
        }

        public override byte[] GetRequestData()
        {
            _requestData = new byte[] { };

            return base.GetRequestData();
        }

        public override IResponse ProcessResponseData(byte[] response)
        {
            try
            {
                base.ProcessResponseData(response);

                this.IsSuccessful = (_responseData?.Length == 1 &&
                                     _responseData[0] == 0x34);
            }
            catch
            {
                this.IsSuccessful = false;
            }

            if (this.IsSuccessful)
            {
                return new SuccessResponse();
            }
            else
            {
                return new FailResponse();
            }
        }
    }
}
