using GreykoMonitor.Communication.Entities;
using System;
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

        public bool IsSuccessful { get; protected set; }

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

        public virtual IResponse ProcessResponseData(byte[] response)
        {
            if (response.Length < _header.Length + 2)
            {
                throw new Exception("Invalid response");
            }

            // check header
            for (int n = 0; n < _header.Length; n++)
            {
                if (response[n] != _header[n])
                {
                    throw new Exception("Invalid response header");
                }
            }

            // check length
            if (response.Length != _header.Length + 1 + response[_header.Length])
            {
                throw new Exception("Invalid response length");
            }

            List<byte> data = new List<byte>();
            for (byte n = 2; n < response.Length - 1; n++)
            {
                data.Add(response[n]);
            }

            // decrement response data values
            for (byte n = 1; n < data.Count; n++)
            {
                data[n] = (byte)(data[n] - n + 1);
            }

            // checksum validation
            if (response[response.Length - 1] != CalculateCheckSum(data.ToArray()) + data.Count - 1)
            {
                throw new Exception("Response checksum validation failed");
            }

            data.RemoveAt(0);

            _responseData = data.ToArray();

            return null; // do not return result in the base class
        }

        private byte CalculateCheckSum(byte[] data)
        {
            int sum = data.Sum(d => d);

            return (byte)(((byte)sum % 0xFF) ^ 0xFF);
        }
    }
}
