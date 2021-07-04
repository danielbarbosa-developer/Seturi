using System;

namespace Seturi.Exceptions
{
    public class InvalidUriException : Exception
    {
        public InvalidUriException()
        {
            
        }

        public InvalidUriException(string message) : base(message)
        {
            
        }

        public InvalidUriException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}