using GreykoMonitor.Communication.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreykoMonitor.Test
{
    [TestClass]
    public class SetBoilerTemperatureCommandTest
    {
        [TestMethod]
        public void SetBoilerTemperatureTo59()
        {
            ICommand command = new SetBoilerTemperatureCommand(59);
            byte[] request = command.GetRequestData();

            string hex = BitConverter.ToString(request).Replace("-", " ");
            Assert.AreEqual(hex, "5A 5A 03 07 3C BC");
        }

        [TestMethod]
        public void SetBoilerTemperatureTo60()
        {
            ICommand command = new SetBoilerTemperatureCommand(60);
            byte[] request = command.GetRequestData();

            string hex = BitConverter.ToString(request).Replace("-", " ");
            Assert.AreEqual(hex, "5A 5A 03 07 3D BB");
        }

        [TestMethod]
        public void SetBoilerTemperatureTo62()
        {
            ICommand command = new SetBoilerTemperatureCommand(62);
            byte[] request = command.GetRequestData();

            string hex = BitConverter.ToString(request).Replace("-", " ");
            Assert.AreEqual(hex, "5A 5A 03 07 3F B9");
        }
    }
}
