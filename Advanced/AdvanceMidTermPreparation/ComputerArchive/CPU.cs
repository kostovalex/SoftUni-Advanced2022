using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        private string brand;
        private int cores;
        private double frequency;
        
        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }

        public string Brand { get => brand; set => brand = value; }
        public int Cores { get => cores; set => cores = value; }
        public double Frequency { get => frequency; set => frequency = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Brand} CPU:");
            sb.AppendLine($"Cores: {Cores}");
            sb.AppendLine($"Frequency: {Frequency:F1} GHz");

            return sb.ToString().Trim();
        }
    }
}
