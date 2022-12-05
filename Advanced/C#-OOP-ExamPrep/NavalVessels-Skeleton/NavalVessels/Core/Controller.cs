using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private IRepository<IVessel> vesselRepo;
        private List<ICaptain> captains;

        public Controller()
        {
            vesselRepo = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            if (captains.Any(c => c.FullName == fullName))
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            captains.Add(new Captain(fullName));
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vesselRepo.FindByName(name) != null)
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }
            
            if (vesselType == "Battleship")
            {
                var battleship = new Battleship(name, mainWeaponCaliber, speed);
                vesselRepo.Add(battleship);
                return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
            }
            else if(vesselType == "Submarine")
            {
                var submarine = new Submarine(name, mainWeaponCaliber, speed);
                vesselRepo.Add(submarine);
                return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (!captains.Any(c => c.FullName == selectedCaptainName))
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (vesselRepo.FindByName(selectedVesselName) == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vesselRepo.Models.First(v => v.Name == selectedVesselName).Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            var selectedCaptain = captains.First(c => c.FullName == selectedCaptainName);
            var selectedVessel = vesselRepo.Models.First(v => v.Name == selectedVesselName);

            selectedCaptain.AddVessel(selectedVessel);
            vesselRepo.Models.First(v => v.Name == selectedVesselName).Captain = selectedCaptain;

            return String.Format(OutputMessages.SuccessfullyAssignCaptain,selectedCaptainName, selectedVesselName);
        }
        public string CaptainReport(string captainFullName)
                => captains.First(c => c.FullName == captainFullName).Report();
        
        public string VesselReport(string vesselName)
                => vesselRepo.Models.First(v => v.Name == vesselName).ToString();

        public string ToggleSpecialMode(string vesselName)
        {
            if (!vesselRepo.Models.Any(v => v.Name == vesselName))
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
            
            var type = vesselRepo.Models.First(v => v.Name == vesselName).GetType().Name;
            
            if (type == "Submarine")
            {
                var submarine = (Submarine)vesselRepo.Models.First(v => v.Name == vesselName);
                submarine.ToggleSubmergeMode();

                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
            else 
            {
                var battleship = (Battleship)vesselRepo.Models.First(v => v.Name == vesselName);
                battleship.ToggleSonarMode();

                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
        }
        public string ServiceVessel(string vesselName)
        {
            if (!vesselRepo.Models.Any(v => v.Name == vesselName))
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            var vessel = vesselRepo.Models.First(v => v.Name == vesselName);
            vessel.RepairVessel();

            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }
        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            if (vesselRepo.FindByName(attackingVesselName) == null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (vesselRepo.FindByName(defendingVesselName) == null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }
            if (vesselRepo.Models.First(v => v.Name == attackingVesselName).ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (vesselRepo.Models.First(v => v.Name == defendingVesselName).ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            var attacker = vesselRepo.Models.First(v => v.Name == attackingVesselName);
            var defender = vesselRepo.Models.First(v => v.Name == defendingVesselName);

            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defender.ArmorThickness);
        }




    }
}
