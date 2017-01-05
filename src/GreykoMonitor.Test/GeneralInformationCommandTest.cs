﻿using System;
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

        [TestMethod]
        public void GeneralInformationResponse1()
        {
            ICommand command = new GeneralInformationCommand();

            byte[] response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x12, 0x4B, 0x57, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x0A, 0x0B, 0x8C,
                                           0x0D, 0x0E, 0x0F, 0x4C, 0x46, 0x92, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x99, 0x1A, 0x1B, 0xFA };
            command.ProcessResponseData(response);
            Assert.AreEqual(command.IsSuccessful, true);
        }

        [TestMethod]
        public void GeneralInformationResponse2()
        {
            ICommand command = new GeneralInformationCommand();

            byte[] response = new byte[] { 0x5A, 0x5A, 0x1D, 0x16, 0x14, 0x12, 0x4B, 0x5C, 0x1B, 0x18, 0x1D, 0x09, 0x09, 0x0A, 0x0B, 0x8C,
                                           0x0D, 0x0E, 0x0F, 0x4C, 0x47, 0x92, 0x13, 0x14, 0x1D, 0x16, 0x17, 0x18, 0x99, 0x1A, 0x1B, 0xEC };
            command.ProcessResponseData(response);
            Assert.AreEqual(command.IsSuccessful, true);
        }
    }
}
