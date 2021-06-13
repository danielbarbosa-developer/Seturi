using System.Collections.Generic;
using Seturi.Entities;

namespace Seturi.Abstractions
{
    public interface IUriCollection
    {
        int Add(Uri uri);

        Uri Get(int uriId);

        IDictionary<int, Uri> GetAll();
    }
}