using GreykoMonitor.Communication;
using GreykoMonitor.Communication.Commands;
using GreykoMonitor.Communication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreykoMonitor
{
    public class GreykoMonitor
    {
        private ICommandProcessor _commandProcessor;

        public GreykoMonitor(ICommandProcessor commandProcessor)
        {
            if (commandProcessor == null) throw new ArgumentNullException(nameof(commandProcessor));

            _commandProcessor = commandProcessor;
        }

        public IResponse GetGeneralInformation()
        {
            ICommand command = new GeneralInformationCommand();

            return _commandProcessor.ProcessCommand(command);
        }
    }
}
