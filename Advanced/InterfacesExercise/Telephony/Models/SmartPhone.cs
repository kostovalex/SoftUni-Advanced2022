namespace Telephony.Models
{
    using System.Linq;
    using System;
    
    using Interfaces;
    public class SmartPhone :ISmartphone
    {
        public string Call(string number)
        {
            if (number.Any(ch => !char.IsDigit(ch)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {number}";
        }
        public string Browse(string url)
        {
            if (url.Any(ch => char.IsDigit(ch)))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

    }
}
