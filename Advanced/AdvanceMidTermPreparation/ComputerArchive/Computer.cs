using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private List<CPU> Multiprocessor;
        private string model;
        private int capacity;

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }       
      
        public int Count { get { return Multiprocessor.Count; }}
        public string Model { get => model; set => model = value; }
        public int Capacity { get => capacity; set => capacity = value; }

        public void Add(CPU cpu)
        {
            if (Capacity>0)
            {
                if (!Multiprocessor.Any(p => p.Brand == cpu.Brand))
                {
                    Multiprocessor.Add(cpu);
                    Capacity--;
                }  
            }
        }

        public bool Remove(string brand)
        {
            if (Multiprocessor.Any(p => p.Brand == brand))
            {
                Multiprocessor = Multiprocessor.Where(p => p.Brand != brand).ToList();
                Capacity++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public CPU MostPowerful()
        {
            if (Count>0)
            {
                CPU mostPowerful = Multiprocessor.OrderByDescending(p => p.Frequency).First();
                return mostPowerful;
            }
            else
            {
                return default;
            }
            
        }

        public CPU GetCPU(string brand)
        {
            if (Multiprocessor.Any(p => p.Brand == brand))
            {
               return Multiprocessor.Where(p => p.Brand == brand).First();
            }
            else
            {
                return default;
            }
        }

        public string Report()
        {
            if (Count > 0 )
            {
                StringBuilder result = new StringBuilder();

                result.AppendLine($"CPUs in the Computer {this.Model}:");
                foreach (var cpu in Multiprocessor)
                {
                    result.AppendLine(cpu.ToString());
                }
                return result.ToString().Trim();
            }
            return null;
        }
    }
}
