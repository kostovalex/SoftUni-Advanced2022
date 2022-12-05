using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private IRepository<IFormulaOneCar> carRepo;
        private IRepository<IPilot> pilotRepo;
        private IRepository<IRace> raceRepo;

        public Controller()
        {
            this.carRepo = new FormulaOneCarRepository();
            this.pilotRepo = new PilotRepository();
            this.raceRepo = new RaceRepository();
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepo.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            pilotRepo.Add(new Pilot(fullName));
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }
        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            if (carRepo.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            if (type == "Ferrari")
            {
                Ferrari car = new Ferrari(model, horsepower, engineDisplacement);
                carRepo.Add(car);

                return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
            }
            else
            {
                Williams car = new Williams(model, horsepower, engineDisplacement);
                carRepo.Add(car);

                return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
            }
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepo.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            var race = new Race(raceName, numberOfLaps);
            raceRepo.Add(race);

            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (pilotRepo.FindByName(pilotName) == null || pilotRepo.FindByName(pilotName).CanRace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (carRepo.FindByName(carModel) == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            var pilot = pilotRepo.FindByName(pilotName);
            var car = carRepo.FindByName(carModel);
            
            pilot.AddCar(car);
            carRepo.Remove(car);

            string type = car.GetType().Name.ToString();

            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, type, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (raceRepo.FindByName(raceName) == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (pilotRepo.FindByName(pilotFullName) == null || !pilotRepo.FindByName(pilotFullName).CanRace 
                || raceRepo.FindByName(raceName).Pilots.Any(p => p.FullName == pilotFullName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            raceRepo.FindByName(raceName).AddPilot(pilotRepo.FindByName(pilotFullName));
            
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }
        public string StartRace(string raceName)
        {
            if (raceRepo.FindByName(raceName) == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (raceRepo.FindByName(raceName).Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (raceRepo.FindByName(raceName).TookPlace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            var race = raceRepo.FindByName(raceName);
            
            var first = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).First();
            var second = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).Skip(1).First();
            var third = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).Skip(2).First();

            race.TookPlace = true;
            first.WinRace();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {first.FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {second.FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {third.FullName} is third in the {raceName} race.");

            return sb.ToString().Trim();

        }
        public string RaceReport()
        {
            var executed = raceRepo.Models.Where(r => r.TookPlace).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var race in executed)
            {
                sb.Append(race.RaceInfo());
            }
            return sb.ToString().Trim();
        }
        public string PilotReport()
        {
            var ordered = pilotRepo.Models.OrderByDescending(p=> p.NumberOfWins).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var pilot in ordered)
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().Trim();
        }


    }
}
