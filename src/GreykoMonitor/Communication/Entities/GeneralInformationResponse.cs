using GreykoMonitor.Communication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreykoMonitor.Communication.Entities
{
    public class GeneralInformationResponse : IResponse
    {
        public string SwVer { get; set; }
        public DateTime Date { get; set; }
        public Mode Mode { get; set; }
        public State State { get; set; }
        public Status Status { get; set; }
        public byte Tset { get; set; }
        public byte Tboiler { get; set; }
        public byte Flame { get; set; }
        public bool Heater { get; set; }
        public bool CHPump { get; set; }
        public bool BF { get; set; }
        public bool FF { get; set; }
        public byte Fan { get; set; }
        public Power Power { get; set; }
        public bool ThermostatStop { get; set; }
    }
}
