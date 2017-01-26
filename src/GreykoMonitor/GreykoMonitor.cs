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

#if DEBUG
            byte[] response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x13, 0x05, 0x57, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x13, 0x0B, 0x8C,
                                           0x0D, 0x0E, 0x0F, 0x4C, 0x49, 0x92, 0x93, 0xB2, 0x1D, 0x16, 0x42, 0x1C, 0x19, 0x1A, 0x1B, 0x5E };

            return command.ProcessResponseData(response);
#else
            return _commandProcessor.ProcessCommand(command);
#endif
        }

        public IResponse SetBoilerTemperature(byte boilerTemperature)
        {
            ICommand command = new SetBoilerTemperatureCommand(boilerTemperature);

            return _commandProcessor.ProcessCommand(command);
        }
    }
}
