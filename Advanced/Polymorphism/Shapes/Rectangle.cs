using System;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get => height; private set => height = value; }
        public double Width { get => width; private set => width = value; }

        public override double CalculateArea()
            => this.Height * this.Width;

        public override double CalculatePerimeter()
            => (this.Width + this.Height) * 2;
        //public override string Draw()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(DrawLine(this.Width, '*', '*'));
        //    for (int i = 1; i < this.Height - 1; ++i)
        //    {
        //        sb.Append(DrawLine(this.Width, '*', ' '));
        //    }
        //    sb.Append(DrawLine(this.Width, '*', '*'));
            
        //    return sb.ToString();
          
        //}
        internal string DrawLine(double width, char end, char mid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(end);
            for (int i = 1; i < width - 1; ++i)
            {
                sb.Append(mid);
            }
            sb.AppendLine(end.ToString());

            return sb.ToString();
        }
    }
}
