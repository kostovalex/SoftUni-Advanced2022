using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;

            renovators = new List<Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count { get { return renovators.Count; } }

        public string AddRenovator(Renovator renovator)
        {
            if (renovators.Count >= NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (renovator.Rate >= 350)
            {
                return "Invalid renovator's rate.";
            }
            else
            {
                renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }
        }

        public bool RemoveRenovator(string name)
        {
            if (renovators.Any(n => n.Name == name))
            {
                Renovator current = renovators.FirstOrDefault(n => n.Name == name);
                renovators.Remove(current);
                return true;
            }
            else
            {
                return false;
            }

        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            var removedCount = 0;
            if (renovators.Any(n => n.Type == type))
            {  
                foreach (var item in renovators)
                {
                    if (item.Type == type)
                    {
                        removedCount++;
                    }
                }
                renovators = renovators.Where(n => n.Type != type).ToList();
                return removedCount;
            }
            else
            {
                return 0;
            }
        }

        public Renovator HireRenovator(string name)
        {
            if (renovators.Any(n => n.Name == name))
            {
                Renovator current = renovators.FirstOrDefault(n => n.Name == name);
                current.Hired = true;
                return current;
            }
            else
            {
                return null;
            }
        }
        public List<Renovator> PayRenovators(int days)
        {
            return renovators.Where(n => n.Days >= days).ToList();

        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {this.Project}:");
            foreach (var item in this.renovators.Where(x => x.Hired == false))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
