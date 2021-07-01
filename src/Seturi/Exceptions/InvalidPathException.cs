using System;

namespace Seturi.Exceptions
{
    public class InvalidPathException : Exception
    {
        public InvalidPathException()
        {
            
        }

        public InvalidPathException(string message) : base(message)
        {
            
        }

        public InvalidPathException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}