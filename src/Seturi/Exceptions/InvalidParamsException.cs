using System;

namespace Seturi.Exceptions
{
    public class InvalidParamsException : Exception
    {
        public InvalidParamsException()
        {
            
        }

        public InvalidParamsException(string message) : base(message)
        {
            
        }

        public InvalidParamsException(string message, Exception inner) : base(message, inner)
        {
            
        }

      
    }
}