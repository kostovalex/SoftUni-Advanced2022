using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> pilots;
        public PilotRepository()
        {
            pilots = new List<IPilot>().AsReadOnly().ToList();
        }
        public IReadOnlyCollection<IPilot> Models => pilots;

        public void Add(IPilot pilot)
            => pilots.Add(pilot);

        public IPilot FindByName(string name)
        {
            return pilots.FirstOrDefault(p => p.FullName == name);
        }

        public bool Remove(IPilot pilot)
        {
            if (pilots.Any(p => p == pilot))
            {
                pilots.Remove(pilot);
                return true;
            }
            return false;
        }
    }
}
