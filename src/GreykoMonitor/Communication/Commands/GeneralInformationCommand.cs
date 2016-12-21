using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreykoMonitor.Communication.Commands
{
    public class GeneralInformationCommand : ICommand
    {
        public byte[] GetRequest()
        {
            throw new NotImplementedException();
        }

        public void ProcessResponse(byte[] response)
        {
            throw new NotImplementedException();
        }
    }
}
