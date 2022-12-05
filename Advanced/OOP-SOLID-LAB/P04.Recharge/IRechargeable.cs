using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge
{
    public interface IRechargeable
    {
        int  Capacity { get; }
        int CurrentPower { get; set; }
        void Recharge();
    }
}
