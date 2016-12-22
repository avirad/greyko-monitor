﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreykoMonitor.Communication.Commands
{
    public abstract class CommandBase : ICommand
    {
        protected byte[] _header = { 0x5A, 0x5A };
        protected abstract byte _commandId { get; set; }
        protected abstract byte[] _requestData { get; set; }
        protected abstract byte[] _responseData { get; set; }

        public virtual byte[] GetRequestData()
        {
            List<byte> request = new List<byte>();

            // data length = 1 byte command Id + requestData.Length + 1 byte checksum
            request.Add((byte)(_requestData.Length + 2));

            // command Id
            request.Add(_commandId);

            // request data
            for (byte n = 0; n < _requestData.Length; n++)
            {
                request.Add((byte)(_requestData[n]));
            }

            // checksum
            request.Add((byte)(CalculateCheckSum(request.ToArray()) + request.Count - 1));

            // increment request data values
            for (byte n = 2; n < _requestData.Length + 2; n++)
            {
                request[n] = (byte)(request[n] + n - 1);
            }

            // header
            request.InsertRange(0, _header);

            return request.ToArray();
        }

        public virtual void ProcessResponseData(byte[] response)
        {
            throw new NotImplementedException();
        }

        private byte CalculateCheckSum(byte[] data)
        {
            int sum = data.Sum(d => d);

            return (byte)((sum % 0xFF) ^ 0xFF);
        }
    }
}
