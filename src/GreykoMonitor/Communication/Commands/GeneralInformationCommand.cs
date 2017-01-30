using GreykoMonitor.Communication.Entities;
using GreykoMonitor.Communication.Enums;
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

        public override byte[] GetRequestData()
        {
            _requestData = new byte[] { };

            return base.GetRequestData();
        }

        public override IResponse ProcessResponseData(byte[] response)
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

            if (this.IsSuccessful)
            {
                return new GeneralInformationResponse()
                {
                    SwVer = _responseData[1].ToString("X").Insert(1, "."),
                    Date = new DateTime(int.Parse(_responseData[7].ToString("X")), int.Parse(_responseData[6].ToString("X")), int.Parse(_responseData[5].ToString("X")),
                                        int.Parse(_responseData[2].ToString("X")), int.Parse(_responseData[3].ToString("X")), int.Parse(_responseData[4].ToString("X"))),
                    Mode = (Mode)_responseData[8],
                    State = (State)_responseData[9],
                    Status = (Status)_responseData[10],
                    IgnitionFail = (_responseData[13] & (1 << 0)) != 0,
                    PelletJam = (_responseData[13] & (1 << 5)) != 0,
                    Tset = _responseData[16],
                    Tboiler = _responseData[17],
                    Flame = _responseData[20],
                    Heater = (_responseData[21] & (1 << 1)) != 0,
                    CHPump = (_responseData[21] & (1 << 3)) != 0,
                    BF = (_responseData[21] & (1 << 4)) != 0,
                    FF = (_responseData[21] & (1 << 5)) != 0,
                    Fan = _responseData[23],
                    Power = (Power)_responseData[24],
                    ThermostatStop = (_responseData[25] & (1 << 7)) != 0
                };
            }
            else
            {
                return new FailResponse();
            }
        }
    }
}
