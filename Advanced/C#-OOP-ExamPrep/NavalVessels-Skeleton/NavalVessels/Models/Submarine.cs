using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double defaultArmorThickness = 200;
        private bool submergeMode;
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, defaultArmorThickness)
        {
        }

        public bool SubmergeMode { get { return submergeMode; } private set { submergeMode = value; } }
        public void ToggleSubmergeMode()
        {
            if (SubmergeMode)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
                SubmergeMode = false;
            }
            else
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
                SubmergeMode = true;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < defaultArmorThickness)
            {
                ArmorThickness = defaultArmorThickness;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            string submergeMode = "";
            if (SubmergeMode)
            {
                submergeMode = "ON";
            }
            else
            {
                submergeMode = "OFF";
            }

            result.AppendLine(base.ToString())
                 .AppendLine($" *Submerge mode: {submergeMode}");

            return result.ToString().TrimEnd();
        }
    }
}
