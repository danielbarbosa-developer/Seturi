using System.Collections.Generic;
using Seturi.Abstractions;
using Seturi.Entities;

namespace Seturi
{
    /// <summary>
    ///  Contains all uris defined on the system to be accessed easily
    /// </summary>
    /// <remarks>
    ///  It is recommended to be used with dependency injection in a singleton
    ///  because it works with data in memory 
    /// </remarks>
    public class UriCollection : IUriCollection
    {
        
        public int Add(Uri uri)
        {
            throw new System.NotImplementedException();
        }

        public Uri Get(int uriId)
        {
            throw new System.NotImplementedException();
        }

        public IDictionary<int, Uri> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}