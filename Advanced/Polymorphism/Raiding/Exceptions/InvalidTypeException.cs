namespace Raiding.Exceptions
{
    using System;
    public class InvalidTypeException : Exception
    {
        private const string DefaultMessage = "Ivalid Type";

        public InvalidTypeException() : base(DefaultMessage)
        {
        }
        public InvalidTypeException(string message) : base(message)
        {
        }
    }
}
