using System;
using System.Text;
using System.Transactions;

namespace EncapsulationExercise
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CANNOT_BE_NEGATIVE, nameof(Length)));
                }
                length = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CANNOT_BE_NEGATIVE, nameof(Width)));
                }
                width = value;
            }
        }
        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CANNOT_BE_NEGATIVE, nameof(Height)));
                }
                height = value;
            }
        }

        public double SurfaceArea()
        {
            return (2*length*width)+LateralSurfaceArea();
        }
        public double LateralSurfaceArea()
        {
            return (2*length*height)+(2*height*width);
        }
        public double Volume()
        {
            return length * height * width;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Surface Area - {SurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}")
                .AppendLine($"Volume - {Volume():f2}");

            return sb.ToString().TrimEnd();

        }
    }
}
