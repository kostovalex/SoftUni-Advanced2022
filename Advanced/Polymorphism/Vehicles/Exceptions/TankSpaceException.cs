using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Exceptions
{
    public class TankSpaceException : Exception
    {
        private string DefaultMessage = "Not enough space in the tank.";
       
        public TankSpaceException(string defaultMessage)
        {
            DefaultMessage = defaultMessage;
        }

        public override string Message => DefaultMessage;
    }
}
