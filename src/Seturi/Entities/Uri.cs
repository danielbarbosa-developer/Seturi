using System;
using System.Reflection;
using System.Text;
using Seturi.Attributes;
using Seturi.Exceptions;

namespace Seturi.Entities
{
    public sealed class Uri
    {
        private readonly string AbsoluteUri;
        public Uri()
        {
            AbsoluteUri = null;
        }

        public Uri(string absoluteUri)
        {
            if (String.IsNullOrEmpty(absoluteUri) || String.IsNullOrWhiteSpace(absoluteUri))
                throw new InvalidUriException("Absolute URI cannot be null or empty");
            
            AbsoluteUri = absoluteUri;
        }
        
        internal Uri(string protocol, string host, string path, string query)
        {
            AbsoluteUri = null;
            Protocol = protocol;
            Host = host;
            Path = path;
            Query = query;
        }
        
        public string Protocol { get; private set; }
        
        public string Host { get; private set; }
        
        public string Path { get; private set; }
        
        public string Query { get; private set; }

        public override string ToString()
        {
            if (AbsoluteUri != null)
                return AbsoluteUri;
            
            return ResolveUriPropertiesToString(this);
        }

        private string ResolveUriPropertiesToString(Uri uri)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(uri.Protocol);
            sb.Append(uri.Host);

            if (!String.IsNullOrEmpty(uri.Path))
                sb.Append(uri.Path);

            if (!String.IsNullOrEmpty(uri.Query))
                sb.Append(uri.Query);

            return sb.ToString();
        }
    }
}