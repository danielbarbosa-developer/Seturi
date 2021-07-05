using Seturi.Entities;

namespace Seturi.Abstractions
{
    
    public interface IUriBuilder
    {
        /// <summary>
        /// Generates the URI object when all properties are defined 
        /// </summary>
        /// <returns>A Uri object</returns>
        Uri GenerateUri();
        /// <summary>
        /// Generates the URI string to final use when all properties are defined 
        /// </summary>
        /// <returns>A URI string to final use </returns>
        string GenerateUriAsString();
        /// <summary>
        /// Add the URI protocol
        /// </summary>
        /// <param name="protocol">The protocol enum type</param>
        void AddProtocol(ProtocolType protocol);
        /// <summary>
        /// Add the host to the URI
        /// </summary>
        /// <param name="host">The URI host (Ex: www.test.com)</param>
        /// <exception cref="InvalidHostException"></exception>
        void AddHost(string host);
        /// <summary>
        /// Add the path for the URI
        /// </summary>
        /// <param name="path">The URI path or additional content</param>
        /// <exception cref="InvalidPathException"></exception>
        void AddPath(string path);
        /// <summary>
        /// Add the query for the URI
        /// </summary>
        /// <param name="methodName">The query method (Ex: "execute" in the query "execute?order=1")</param>
        /// <param name="paramsObject">The model class that contains properties marked with UriParamAttribute and can be serialized</param>
        /// <typeparam name="T">The model class that contains properties marked with UriParamAttribute and can be serialized</typeparam>
        /// <exception cref="InvalidQueryException"></exception>
        void AddQuery<T>(string methodName, T paramsObject);
    }
}