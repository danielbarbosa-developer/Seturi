using System;

namespace Seturi.Exceptions
{
    public class UriBuilderException : Exception
    {
        public UriBuilderException()
        {
            
        }

        public UriBuilderException(string message) : base(message)
        {
            
        }

        public UriBuilderException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}