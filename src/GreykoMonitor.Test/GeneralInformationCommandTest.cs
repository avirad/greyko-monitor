using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreykoMonitor.Communication.Commands;
using GreykoMonitor.Communication.Commands.Enums;

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

            ((GeneralInformationCommand)command).AssertResponse(SwVer: "1.3", Mode: Mode.Auto, State: State.CHPriority, Status: Status.Idle,
                Tset: 60, Tboiler: 53, Flame: 0, Heater: false, CHPump: false, BF: false, FF: false, Fan: 0, Power: Power.Idle, ThermostatStop: true);

            response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x12, 0x4B, 0x5C, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x0A, 0x0B, 0x8C,
                                    0x0D, 0x0E, 0x0F, 0x4C, 0x47, 0x92, 0x13, 0x14, 0x1D, 0x16, 0x17, 0x18, 0x99, 0x1A, 0x1B, 0xEC };
            command.ProcessResponseData(response);

            ((GeneralInformationCommand)command).AssertResponse(SwVer: "1.3", Mode: Mode.Auto, State: State.CHPriority, Status: Status.Idle,
                Tset: 60, Tboiler: 54, Flame: 0, Heater: false, CHPump: true, BF: false, FF: false, Fan: 0, Power: Power.Idle, ThermostatStop: true);
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

            ((GeneralInformationCommand)command).AssertResponse(SwVer: "1.3", Mode: Mode.Auto, State: State.CHPriority, Status: Status.Idle,
                Tset: 60, Tboiler: 53, Flame: 0, Heater: false, CHPump: true, BF: false, FF: false, Fan: 0, Power: Power.Idle, ThermostatStop: true);

            response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x12, 0x4C, 0x5C, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x0B, 0x0B, 0x8C,
                                    0x0D, 0x0E, 0x0F, 0x4C, 0x46, 0x92, 0x13, 0x14, 0x2D, 0x16, 0x7B, 0x18, 0x19, 0x1A, 0x1B, 0xF7 };
            command.ProcessResponseData(response);

            ((GeneralInformationCommand)command).AssertResponse(SwVer: "1.3", Mode: Mode.Auto, State: State.CHPriority, Status: Status.FanCleaning,
                Tset: 60, Tboiler: 53, Flame: 0, Heater: false, CHPump: true, BF: true, FF: false, Fan: 100, Power: Power.Idle, ThermostatStop: false);

            response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x12, 0x53, 0x07, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x0D, 0x0B, 0x8C,
                                    0x0D, 0x0E, 0x0F, 0x4C, 0x46, 0x92, 0x13, 0x14, 0x1D, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0xB7 };
            command.ProcessResponseData(response);

            ((GeneralInformationCommand)command).AssertResponse(SwVer: "1.3", Mode: Mode.Auto, State: State.CHPriority, Status: Status.Wait,
                Tset: 60, Tboiler: 53, Flame: 0, Heater: false, CHPump: true, BF: false, FF: false, Fan: 0, Power: Power.Idle, ThermostatStop: false);

            response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x12, 0x53, 0x0C, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x0E, 0x0B, 0x8C,
                                    0x0D, 0x0E, 0x0F, 0x4C, 0x46, 0x92, 0x13, 0x14, 0x4D, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1F, 0x7D };
            command.ProcessResponseData(response);

            ((GeneralInformationCommand)command).AssertResponse(SwVer: "1.3", Mode: Mode.Auto, State: State.CHPriority, Status: Status.Loading,
                Tset: 60, Tboiler: 53, Flame: 0, Heater: false, CHPump: true, BF: true, FF: true, Fan: 0, Power: Power.Idle, ThermostatStop: false);
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

            ((GeneralInformationCommand)command).AssertResponse(SwVer: "1.3", Mode: Mode.Auto, State: State.CHPriority, Status: Status.Burning,
                Tset: 60, Tboiler: 56, Flame: 158, Heater: false, CHPump: true, BF: false, FF: false, Fan: 43, Power: Power.P3, ThermostatStop: false);

            response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x13, 0x05, 0x5C, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x13, 0x0B, 0x8C,
                                    0x0D, 0x0E, 0x0F, 0x4C, 0x4A, 0x92, 0x93, 0xB1, 0x1D, 0x16, 0x40, 0x1B, 0x19, 0x1A, 0x1B, 0x5C };
            command.ProcessResponseData(response);

            ((GeneralInformationCommand)command).AssertResponse(SwVer: "1.3", Mode: Mode.Auto, State: State.CHPriority, Status: Status.Burning,
                Tset: 60, Tboiler: 57, Flame: 157, Heater: false, CHPump: true, BF: false, FF: false, Fan: 41, Power: Power.P2, ThermostatStop: false);
        }

        /// <summary>
        /// Ignition1 -> Unfolding
        /// </summary>
        [TestMethod]
        public void Ignition1ToUnfolding()
        {
            ICommand command = new GeneralInformationCommand();

            byte[] response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x12, 0x55, 0x47, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x10, 0x0B, 0x8C,
                                           0x0D, 0x0E, 0x0F, 0x4C, 0x46, 0x92, 0x93, 0xA1, 0x17, 0x16, 0x3E, 0x18, 0x19, 0x1A, 0x1B, 0x44 };
            command.ProcessResponseData(response);

            ((GeneralInformationCommand)command).AssertResponse(SwVer: "1.3", Mode: Mode.Auto, State: State.CHPriority, Status: Status.Ignition1,
                Tset: 60, Tboiler: 53, Flame: 141, Heater: true, CHPump: false, BF: false, FF: false, Fan: 39, Power: Power.Idle, ThermostatStop: false);

            response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x12, 0x55, 0x4C, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x12, 0x0B, 0x8C,
                                    0x0D, 0x0E, 0x0F, 0x4C, 0x46, 0x92, 0x93, 0xAC, 0x15, 0x16, 0x41, 0x18, 0x19, 0x1A, 0x1B, 0x31 };
            command.ProcessResponseData(response);

            ((GeneralInformationCommand)command).AssertResponse(SwVer: "1.3", Mode: Mode.Auto, State: State.CHPriority, Status: Status.Unfolding,
                Tset: 60, Tboiler: 53, Flame: 152, Heater: false, CHPump: false, BF: false, FF: false, Fan: 42, Power: Power.Idle, ThermostatStop: false);
        }
    }

    #region Extensions
    static class Extensions
    {
        public static void AssertResponse(this GeneralInformationCommand command, string SwVer, Mode Mode, State State, Status Status,
            byte Tset, byte Tboiler, byte Flame, bool Heater, bool CHPump, bool BF, bool FF, byte Fan, Power Power, bool ThermostatStop)
        {
            Assert.AreEqual(command.IsSuccessful, true);

            Assert.AreEqual(command.SwVer, SwVer);
            Assert.AreEqual(command.Mode, Mode);
            Assert.AreEqual(command.State, State);
            Assert.AreEqual(command.Status, Status);
            Assert.AreEqual(command.Tset, Tset);
            Assert.AreEqual(command.Tboiler, Tboiler);
            Assert.AreEqual(command.Flame, Flame);
            Assert.AreEqual(command.Heater, Heater);
            Assert.AreEqual(command.CHPump, CHPump);
            Assert.AreEqual(command.BF, BF);
            Assert.AreEqual(command.FF, FF);
            Assert.AreEqual(command.Fan, Fan);
            Assert.AreEqual(command.Power, Power);
            Assert.AreEqual(command.ThermostatStop, ThermostatStop);
        }
    }
    #endregion
}
