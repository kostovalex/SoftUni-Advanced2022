using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> models;
        public VesselRepository()
        {
            models = new List<IVessel>().AsReadOnly().ToList();
        }
        public IReadOnlyCollection<IVessel> Models { get => models; }

        public void Add(IVessel model)
        {
            models.Add(model);
        }

        public IVessel FindByName(string name)
                => models.FirstOrDefault(m => m.Name == name);

        public bool Remove(IVessel model)
        {
            if (models.Any(m => m == model))
            {
                models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
