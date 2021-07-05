using System;
using System.Reflection;
using System.Text;
using Seturi.Attributes;
using Seturi.Exceptions;

namespace Seturi.Entities
{
    /// <summary>
    /// A class used to work with URIs
    /// </summary>
    public sealed class Uri
    {
        private readonly string AbsoluteUri;
        
        /// <summary>
        /// Use this constructor if you already have your URI string complete and only want to generate its URI object
        /// </summary>
        /// <param name="absoluteUri">Your complete URI</param>
        /// <exception cref="InvalidUriException"></exception>
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
        
        /// <summary>
        /// The URI protocol (Ex: Https)
        /// </summary>
        public string Protocol { get; private set; }
        
        /// <summary>
        /// The URI host (Ex:www.test.com)
        /// </summary>
        public string Host { get; private set; }
        
        /// <summary>
        /// The URI path or additional content 
        /// </summary>
        public string Path { get; private set; }
        
        /// <summary>
        /// The URI query (Ex: execute?order=1)
        /// </summary>
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