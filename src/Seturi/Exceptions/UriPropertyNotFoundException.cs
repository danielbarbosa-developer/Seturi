using System;

namespace Seturi.Exceptions
{
    public class UriPropertyNotFoundException : Exception
    {
        public UriPropertyNotFoundException()
        {
            
        }

        public UriPropertyNotFoundException(string message) : base(message)
        {
            
        }

        public UriPropertyNotFoundException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}