using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreykoMonitor.Communication.Commands.Enums
{
    public enum Status
    {
        Idle = 0,
        FanCleaning = 1,
        Cleaner = 2,
        Wait = 3,
        Loading = 4,
        Heating = 5,
        Ignition1 = 6,
        Ignition2 = 7,
        Unfolding = 8,
        Burning = 9,
        Extinction = 10
    }
}
