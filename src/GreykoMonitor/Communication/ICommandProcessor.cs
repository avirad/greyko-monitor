using GreykoMonitor.Communication.Commands;
using GreykoMonitor.Communication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreykoMonitor.Communication
{
    public interface ICommandProcessor
    {
        IResponse ProcessCommand(ICommand command);
    }
}
