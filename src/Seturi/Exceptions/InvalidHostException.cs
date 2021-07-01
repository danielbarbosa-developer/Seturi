using System;

namespace Seturi.Exceptions
{
    public class InvalidHostException : Exception
    {
        public InvalidHostException()
        {
            
        }

        public InvalidHostException(string message) : base(message)
        {
            
        }

        public InvalidHostException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}