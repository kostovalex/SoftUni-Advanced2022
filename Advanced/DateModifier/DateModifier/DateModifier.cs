using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public int DifferenceInDays { get; set; }

        public int DifferenceCalculator(string firstDateInString, string secondDateInString)
        {
            DateTime firstDate = new DateTime();
            DateTime secondDate = new DateTime();

            firstDate = DateTime.Parse(firstDateInString);
            secondDate = DateTime.Parse(secondDateInString);

            TimeSpan difference = firstDate.Subtract(secondDate);
             
            return Math.Abs(difference.Days);
        }
    }
}
