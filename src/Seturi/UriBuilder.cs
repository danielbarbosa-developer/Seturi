using System;
using System.Collections.Generic;
using System.Text;
using Seturi.Abstractions;
using Seturi.Attributes;
using Seturi.Entities;
using Seturi.Exceptions;
using Seturi.Services;
using Uri = Seturi.Entities.Uri;

namespace Seturi
{
    /// <summary>
    /// Offers methods to add URI components and generates URIs
    /// </summary>
    public class UriBuilder : IUriBuilder
    {
        private  string Protocol { get; set; }
        
        private  string Host { get; set; }
        
        private  string Path { get; set; }
        
        private  string Query { get; set; }

        private readonly ReflectionServices _reflection;

        public UriBuilder()
        {
            _reflection = new ReflectionServices();
        }
        /// <summary>
        /// Generates the URI object when all properties are defined 
        /// </summary>
        /// <returns>A Uri object</returns>
        public Uri GenerateUri()
        {
            ValidateRequiredParams(this);
            var uri = new Uri(Protocol, Host, Path, Query);
            return uri;
        }
        
        /// <summary>
        /// Generates the URI string to final use when all properties are defined 
        /// </summary>
        /// <returns>A URI string to final use </returns>
        public string GenerateUriAsString()
        {
            ValidateRequiredParams(this);
            var uri = new Uri(Protocol, Host, Path, Query);
            return uri.ToString();
        }
        
        /// <summary>
        /// Add the URI protocol
        /// </summary>
        /// <param name="protocol">The protocol enum type</param>
        public void AddProtocol(ProtocolType protocol)
        {
            if (protocol == ProtocolType.Http)
                this.Protocol = Entities.Protocol.Http;
            else
                this.Protocol = Entities.Protocol.Https;
        }

        /// <summary>
        /// Add the host to the URI
        /// </summary>
        /// <param name="host">The URI host (Ex: www.test.com)</param>
        /// <exception cref="InvalidHostException"></exception>
        public void AddHost(string host)
        {
            if (String.IsNullOrEmpty(host) || String.IsNullOrWhiteSpace(host))
                throw new InvalidHostException("Parameter host cannot be null or empty");
            
            this.Host = SetComponentEnd(host);
        }
        
        /// <summary>
        /// Add the path for the URI
        /// </summary>
        /// <param name="path">The URI path or additional content</param>
        /// <exception cref="InvalidPathException"></exception>
        public void AddPath(string path)
        {
            if (String.IsNullOrEmpty(path) || String.IsNullOrWhiteSpace(path))
                throw new InvalidPathException("Parameter path cannot be null or empty");
            
            this.Path = SetComponentEnd(path);
        }

        /// <summary>
        /// Add the query for the URI
        /// </summary>
        /// <param name="methodName">The query method (Ex: "execute" in the query "execute?order=1")</param>
        /// <param name="paramsObject">The model class that contains properties marked with UriParamAttribute and can be serialized</param>
        /// <typeparam name="T">The model class that contains properties marked with UriParamAttribute and can be serialized</typeparam>
        /// <exception cref="InvalidQueryException"></exception>
        public void AddQuery<T>(string methodName, T paramsObject)
        {
            if (String.IsNullOrEmpty(methodName) || String.IsNullOrWhiteSpace(methodName))
                throw new InvalidQueryException("Parameter method cannot be null or empty in this context");
            
            var type = paramsObject.GetType();
            var parameters = _reflection.GetAttributeFields(type, paramsObject);

            Query = methodName + GenerateParamsString(parameters);

        }

        private string SetComponentEnd(string component)
        {
            if (component.EndsWith("/"))
                return component;

            component += "/";

            return component;
        }

        private string GenerateParamsString(List<UriParam> parameters)
        {
            var strBuilder = new StringBuilder();

            foreach (var param in parameters)
            {
                if (String.IsNullOrEmpty(strBuilder.ToString()))
                {
                    strBuilder.Append("?");
                    strBuilder.Append(param.ParamName + "=" + param.Value.ToString());
                }
                else
                {
                    strBuilder.Append("&");
                    strBuilder.Append(param.ParamName + "=" + param.Value.ToString());
                }
            }
            return strBuilder.ToString();
        }

        private void ValidateRequiredParams(UriBuilder builder)
        {
            if (String.IsNullOrEmpty(builder.Protocol))
                throw new UriPropertyNotFoundException(
                    "Protocol is a URI property required in this context, consider use the method AddProtocol() to define it");
            
            if (String.IsNullOrEmpty(builder.Host))
                throw new UriPropertyNotFoundException("Host is a URI property required in this context, consider use the method AddHost() to define it");
        }
    }
}