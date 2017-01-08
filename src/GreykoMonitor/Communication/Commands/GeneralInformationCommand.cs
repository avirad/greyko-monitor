using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreykoMonitor.Communication.Commands
{
    public class GeneralInformationCommand : CommandBase, ICommand
    {
        protected const byte _expectedResponseDataLength = 28;

        protected override byte _commandId { get; set; } = 0x01;
        protected override byte[] _requestData { get; set; }
        protected override byte[] _responseData { get; set; }

        #region Public properties
        public byte Tset { get { return _responseData[16]; } }

        public byte Tboiler { get { return _responseData[17]; } }

        public byte Flame { get { return _responseData[20]; } }

        public bool Heater { get { return (_responseData[21] & (1 << 1)) != 0; } }
        public bool CHPump { get { return (_responseData[21] & (1 << 3)) != 0; } }
        public bool BF { get { return (_responseData[21] & (1 << 4)) != 0; } }
        public bool FF { get { return (_responseData[21] & (1 << 5)) != 0; } }

        public byte Fan { get { return _responseData[23]; } }

        public bool ThermostatStop { get { return (_responseData[25] & (1 << 7)) != 0; } }
        #endregion

        public override byte[] GetRequestData()
        {
            _requestData = new byte[] { };

            return base.GetRequestData();
        }

        public override void ProcessResponseData(byte[] response)
        {
            try
            {
                base.ProcessResponseData(response);

                this.IsSuccessful = (_responseData?.Length == _expectedResponseDataLength);
            }
            catch
            {
                this.IsSuccessful = false;
            }
        }
    }
}
