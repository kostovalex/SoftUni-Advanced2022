using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combarExp;
        private List<IVessel> vessels;

        public Captain(string fullname)
        {
            FullName = fullname;
            CombatExperience = 0;
            vessels = new List<IVessel>();
        }
        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.FullName), ExceptionMessages.InvalidCaptainName);
                }
                fullName = value;
            }
        }

        public int CombatExperience { get => combarExp; private set => combarExp = value; }

        public ICollection<IVessel> Vessels { get => vessels; private set => value = vessels; }
        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");
            if (vessels.Count>0)
            {
                foreach (var vessel in vessels)
                {
                    result.AppendLine(vessel.ToString());
                }
            }

            return result.ToString().Trim();
        }
    }
}
