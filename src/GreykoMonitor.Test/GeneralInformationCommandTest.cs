using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreykoMonitor.Communication.Commands;

namespace GreykoMonitor.Test
{
    [TestClass]
    public class GeneralInformationCommandTest
    {
        [TestMethod]
        public void GeneralInformation()
        {
            ICommand command = new GeneralInformationCommand();
            byte[] request = command.GetRequestData();

            string hex = BitConverter.ToString(request).Replace("-", " ");
            Assert.AreEqual(hex, "5A 5A 02 01 FD");
        }

        /// <summary>
        /// Tboiler increased from 53 to 54 and the burner turned the water pump ON.
        /// </summary>
        [TestMethod]
        public void TurnCHPumpON()
        {
            ICommand command = new GeneralInformationCommand();

            byte[] response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x12, 0x4B, 0x57, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x0A, 0x0B, 0x8C,
                                           0x0D, 0x0E, 0x0F, 0x4C, 0x46, 0x92, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x99, 0x1A, 0x1B, 0xFA };
            command.ProcessResponseData(response);

            Assert.AreEqual(command.IsSuccessful, true);
            Assert.AreEqual(((GeneralInformationCommand)command).Tset, 60);
            Assert.AreEqual(((GeneralInformationCommand)command).Tboiler, 53);
            Assert.AreEqual(((GeneralInformationCommand)command).Flame, 0);
            Assert.AreEqual(((GeneralInformationCommand)command).Heater, false);
            Assert.AreEqual(((GeneralInformationCommand)command).CHPump, false);
            Assert.AreEqual(((GeneralInformationCommand)command).BF, false);
            Assert.AreEqual(((GeneralInformationCommand)command).FF, false);
            Assert.AreEqual(((GeneralInformationCommand)command).Fan, 0);
            Assert.AreEqual(((GeneralInformationCommand)command).ThermostatStop, true);

            response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x12, 0x4B, 0x5C, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x0A, 0x0B, 0x8C,
                                    0x0D, 0x0E, 0x0F, 0x4C, 0x47, 0x92, 0x13, 0x14, 0x1D, 0x16, 0x17, 0x18, 0x99, 0x1A, 0x1B, 0xEC };
            command.ProcessResponseData(response);

            Assert.AreEqual(command.IsSuccessful, true);
            Assert.AreEqual(((GeneralInformationCommand)command).Tset, 60);
            Assert.AreEqual(((GeneralInformationCommand)command).Tboiler, 54);
            Assert.AreEqual(((GeneralInformationCommand)command).Flame, 0);
            Assert.AreEqual(((GeneralInformationCommand)command).Heater, false);
            Assert.AreEqual(((GeneralInformationCommand)command).CHPump, true);
            Assert.AreEqual(((GeneralInformationCommand)command).BF, false);
            Assert.AreEqual(((GeneralInformationCommand)command).FF, false);
            Assert.AreEqual(((GeneralInformationCommand)command).Fan, 0);
            Assert.AreEqual(((GeneralInformationCommand)command).ThermostatStop, true);
        }

        /// <summary>
        /// Idle -> Fan Cleaning -> Wait -> Loading
        /// </summary>
        [TestMethod]
        public void IdleFanCleaningLoading()
        {
            ICommand command = new GeneralInformationCommand();

            byte[] response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x12, 0x4C, 0x27, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x0A, 0x0B, 0x8C,
                                           0x0D, 0x0E, 0x0F, 0x4C, 0x46, 0x92, 0x13, 0x14, 0x1D, 0x16, 0x17, 0x18, 0x99, 0x1A, 0x1B, 0x21 };
            command.ProcessResponseData(response);

            Assert.AreEqual(command.IsSuccessful, true);
            Assert.AreEqual(((GeneralInformationCommand)command).Tset, 60);
            Assert.AreEqual(((GeneralInformationCommand)command).Tboiler, 53);
            Assert.AreEqual(((GeneralInformationCommand)command).Flame, 0);
            Assert.AreEqual(((GeneralInformationCommand)command).Heater, false);
            Assert.AreEqual(((GeneralInformationCommand)command).CHPump, true);
            Assert.AreEqual(((GeneralInformationCommand)command).BF, false);
            Assert.AreEqual(((GeneralInformationCommand)command).FF, false);
            Assert.AreEqual(((GeneralInformationCommand)command).Fan, 0);
            Assert.AreEqual(((GeneralInformationCommand)command).ThermostatStop, true);

            response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x12, 0x4C, 0x5C, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x0B, 0x0B, 0x8C,
                                    0x0D, 0x0E, 0x0F, 0x4C, 0x46, 0x92, 0x13, 0x14, 0x2D, 0x16, 0x7B, 0x18, 0x19, 0x1A, 0x1B, 0xF7 };
            command.ProcessResponseData(response);

            Assert.AreEqual(command.IsSuccessful, true);
            Assert.AreEqual(((GeneralInformationCommand)command).Tset, 60);
            Assert.AreEqual(((GeneralInformationCommand)command).Tboiler, 53);
            Assert.AreEqual(((GeneralInformationCommand)command).Flame, 0);
            Assert.AreEqual(((GeneralInformationCommand)command).Heater, false);
            Assert.AreEqual(((GeneralInformationCommand)command).CHPump, true);
            Assert.AreEqual(((GeneralInformationCommand)command).BF, true);
            Assert.AreEqual(((GeneralInformationCommand)command).FF, false);
            Assert.AreEqual(((GeneralInformationCommand)command).Fan, 100);
            Assert.AreEqual(((GeneralInformationCommand)command).ThermostatStop, false);

            response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x12, 0x53, 0x07, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x0D, 0x0B, 0x8C,
                                    0x0D, 0x0E, 0x0F, 0x4C, 0x46, 0x92, 0x13, 0x14, 0x1D, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0xB7 };
            command.ProcessResponseData(response);

            Assert.AreEqual(command.IsSuccessful, true);
            Assert.AreEqual(((GeneralInformationCommand)command).Tset, 60);
            Assert.AreEqual(((GeneralInformationCommand)command).Tboiler, 53);
            Assert.AreEqual(((GeneralInformationCommand)command).Flame, 0);
            Assert.AreEqual(((GeneralInformationCommand)command).Heater, false);
            Assert.AreEqual(((GeneralInformationCommand)command).CHPump, true);
            Assert.AreEqual(((GeneralInformationCommand)command).BF, false);
            Assert.AreEqual(((GeneralInformationCommand)command).FF, false);
            Assert.AreEqual(((GeneralInformationCommand)command).Fan, 0);
            Assert.AreEqual(((GeneralInformationCommand)command).ThermostatStop, false);

            response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x12, 0x53, 0x0C, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x0E, 0x0B, 0x8C,
                                    0x0D, 0x0E, 0x0F, 0x4C, 0x46, 0x92, 0x13, 0x14, 0x4D, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1F, 0x7D };
            command.ProcessResponseData(response);

            Assert.AreEqual(command.IsSuccessful, true);
            Assert.AreEqual(((GeneralInformationCommand)command).Tset, 60);
            Assert.AreEqual(((GeneralInformationCommand)command).Tboiler, 53);
            Assert.AreEqual(((GeneralInformationCommand)command).Flame, 0);
            Assert.AreEqual(((GeneralInformationCommand)command).Heater, false);
            Assert.AreEqual(((GeneralInformationCommand)command).CHPump, true);
            Assert.AreEqual(((GeneralInformationCommand)command).BF, true);
            Assert.AreEqual(((GeneralInformationCommand)command).FF, true);
            Assert.AreEqual(((GeneralInformationCommand)command).Fan, 0);
            Assert.AreEqual(((GeneralInformationCommand)command).ThermostatStop, false);
        }

        /// <summary>
        /// P3 -> P2
        /// </summary>
        [TestMethod]
        public void P3ToP2()
        {
            ICommand command = new GeneralInformationCommand();

            byte[] response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x13, 0x05, 0x57, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x13, 0x0B, 0x8C,
                                           0x0D, 0x0E, 0x0F, 0x4C, 0x49, 0x92, 0x93, 0xB2, 0x1D, 0x16, 0x42, 0x1C, 0x19, 0x1A, 0x1B, 0x5E };
            command.ProcessResponseData(response);

            Assert.AreEqual(command.IsSuccessful, true);
            Assert.AreEqual(((GeneralInformationCommand)command).Tset, 60);
            Assert.AreEqual(((GeneralInformationCommand)command).Tboiler, 56);
            Assert.AreEqual(((GeneralInformationCommand)command).Flame, 158);
            Assert.AreEqual(((GeneralInformationCommand)command).Heater, false);
            Assert.AreEqual(((GeneralInformationCommand)command).CHPump, true);
            Assert.AreEqual(((GeneralInformationCommand)command).BF, false);
            Assert.AreEqual(((GeneralInformationCommand)command).FF, false);
            Assert.AreEqual(((GeneralInformationCommand)command).Fan, 43);
            Assert.AreEqual(((GeneralInformationCommand)command).ThermostatStop, false);

            response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x13, 0x05, 0x5C, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x13, 0x0B, 0x8C,
                                    0x0D, 0x0E, 0x0F, 0x4C, 0x4A, 0x92, 0x93, 0xB1, 0x1D, 0x16, 0x40, 0x1B, 0x19, 0x1A, 0x1B, 0x5C };
            command.ProcessResponseData(response);

            Assert.AreEqual(command.IsSuccessful, true);
            Assert.AreEqual(((GeneralInformationCommand)command).Tset, 60);
            Assert.AreEqual(((GeneralInformationCommand)command).Tboiler, 57);
            Assert.AreEqual(((GeneralInformationCommand)command).Flame, 157);
            Assert.AreEqual(((GeneralInformationCommand)command).Heater, false);
            Assert.AreEqual(((GeneralInformationCommand)command).CHPump, true);
            Assert.AreEqual(((GeneralInformationCommand)command).BF, false);
            Assert.AreEqual(((GeneralInformationCommand)command).FF, false);
            Assert.AreEqual(((GeneralInformationCommand)command).Fan, 41);
            Assert.AreEqual(((GeneralInformationCommand)command).ThermostatStop, false);
        }
    }
}
