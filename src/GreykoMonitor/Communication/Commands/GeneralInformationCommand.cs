using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreykoMonitor.Communication.Commands
{
    public class GeneralInformationCommand : CommandBase, ICommand
    {
        protected override byte _commandId { get; set; } = 0x01;
        protected override byte[] _requestData { get; set; }
        protected override byte[] _responseData { get; set; }

        public override byte[] GetRequestData()
        {
            _requestData = new byte[] { };

            return base.GetRequestData();
        }

        public override void ProcessResponseData(byte[] response)
        {
            try
            {
                base.ProcessResponseData(response);

                this.IsSuccessful = true;
            }
            catch
            {
                this.IsSuccessful = false;
            }
        }
    }
}
