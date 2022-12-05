using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races; //Check this out
        public RaceRepository()
        {
            races = new List<IRace>().AsReadOnly().ToList();
        }
        public IReadOnlyCollection<IRace> Models => races;

        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IRace FindByName(string name)
        {
            return races.FirstOrDefault(r => r.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            if (races.Any(r => r == model))
            {
                races.Remove(model);
                return true;
            }
            return false;
        }
    }
}
