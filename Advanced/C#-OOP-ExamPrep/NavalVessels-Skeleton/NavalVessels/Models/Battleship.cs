using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double defaultArmorThickness = 300;
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, defaultArmorThickness)
        {
        }

        public bool SonarMode { get { return sonarMode; } private set { sonarMode = value; } }

        public void ToggleSonarMode()
        {
            if (SonarMode)
            {
                SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
            else
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
                SonarMode = true;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < defaultArmorThickness)
            {
                this.ArmorThickness = defaultArmorThickness;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();           

            string sonarMode = "";
            if (SonarMode)
            {
                sonarMode = "ON";
            }
            else
            {
                sonarMode = "OFF";
            }

            result.AppendLine(base.ToString())
                .AppendLine($" *Sonar mode: {sonarMode}");

            return result.ToString().TrimEnd();
        }
    }
}
