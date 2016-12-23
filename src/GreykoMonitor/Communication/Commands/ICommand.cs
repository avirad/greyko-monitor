using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreykoMonitor.Communication.Commands
{
    public interface ICommand
    {
        byte[] GetRequestData();
        void ProcessResponseData(byte[] response);
        bool IsSuccessful { get; }
    }
}
