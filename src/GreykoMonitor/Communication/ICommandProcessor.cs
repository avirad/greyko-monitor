using GreykoMonitor.Communication.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreykoMonitor.Communication
{
    public interface ICommandProcessor
    {
        void ProcessCommand(ICommand command);
    }
}
