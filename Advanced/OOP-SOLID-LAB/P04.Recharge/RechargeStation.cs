using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge
{
    public class RechargeStation
    {
        private IRechargeable rechargeable;

        public RechargeStation(IRechargeable rechargeable)
        {
            Rechargeable = rechargeable;
        }

        public IRechargeable Rechargeable { get => rechargeable;  private set => rechargeable = value; }

        public void Recharge()
        {
            rechargeable.CurrentPower = rechargeable.Capacity;
        }
    }
}
