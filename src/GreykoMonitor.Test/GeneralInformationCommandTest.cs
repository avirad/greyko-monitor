using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreykoMonitor.Communication.Commands;

namespace GreykoMonitor.Test
{
    [TestClass]
    public class GeneralInformationCommandTest
    {
        [TestMethod]
        public void Test1()
        {
            ICommand command = new GeneralInformationCommand();
            byte[] request = command.GetRequestData();
        }
    }
}
