namespace Telephony.Models
{
    using System;
    using System.Linq;

    using Interfaces;
    public class StationaryPhone : IStationaryPhone
    {
        public string Call(string number)
        {
            if (number.Any(ch => !char.IsDigit(ch)))
            {
                throw new ArgumentException("Invalid number!");
            }
           
            return $"Dialing... {number}";
        }
    }
}
