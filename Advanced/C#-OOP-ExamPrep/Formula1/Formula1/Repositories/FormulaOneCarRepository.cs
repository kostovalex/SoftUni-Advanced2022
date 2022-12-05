using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> cars;
        public FormulaOneCarRepository()
        {
            cars = new List<IFormulaOneCar>().AsReadOnly().ToList();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models
        {
            get { return cars; }
        }

        public void Add(IFormulaOneCar car)
        {
            cars.Add(car);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return cars.FirstOrDefault(m => m.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            if (cars.Any(m => m == model))
            {
                cars.Remove(model);
                return true;
            }
            return false;
        }
    }
}
