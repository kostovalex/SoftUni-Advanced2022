using System;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get => radius; private set => radius = value; }

        public override double CalculateArea()
            => Math.PI * this.Radius * this.Radius;


        public override double CalculatePerimeter()
            => 2 * Math.PI * this.Radius;

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            string symbol = "*";
            double thickness = 0.4;
            double rIn = radius - thickness, rOut = radius + thickness;

            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {                     
                        Console.Write(symbol);
                    }
                    else
                    {                      
                        Console.Write(" ");
                    }
                }                
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
