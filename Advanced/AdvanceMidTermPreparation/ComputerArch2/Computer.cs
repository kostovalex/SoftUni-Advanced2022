using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private string model;
        private int capacity;
        private List<CPU> multiprocessor;

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public List<CPU> Multiprocessor
        {
            get { return multiprocessor; }
            set { multiprocessor = value; }
        }

        public int Count { get { return multiprocessor.Count; } }

        public void Add(CPU cpu)
        {
            if (capacity > 0)
            {
                multiprocessor.Add(cpu);
                capacity--;
            }
        }
        public bool Remove(string brand)
        {
            if (multiprocessor.Any(p=> p.Brand == brand))
            {
                for (int i = 0; i < Count; i++)
                {
                    if (multiprocessor[i].Brand == brand)
                    {
                        multiprocessor.Remove(Multiprocessor[i]);
                        capacity++;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public CPU MostPowerful()
        {
            CPU wanted = multiprocessor.OrderByDescending(p => p.Frequency).First();
            return wanted;
        }

        public CPU GetCPU(string brand)
        {
            if (multiprocessor.Any(p=> p.Brand == brand))
            {
                CPU wanted = multiprocessor.Where(p => p.Brand == brand).First();
                return wanted;
            }
            else
            {
                return null;
            }
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"CPUs in the Computer {this.Model}:");
            foreach (CPU cpu in multiprocessor)
            {
                result.AppendLine(cpu.ToString());
            }
            return result.ToString().Trim();
        }
    }
}
