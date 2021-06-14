using System.Reflection;
using Seturi.Abstractions;
using Seturi.Entities;

namespace Seturi
{
    public class UriBuilder : IUriBuilder
    {
        private  string Protocol { get; set; }
        
        private  string Host { get; set; }
        
        private  string Path { get; set; }
        
        private  string Params { get; set; }
        public Uri GenerateUri()
        {
            var uri = new Uri(Protocol, Host, Path, Params);
            return uri;
        }

        public string GenerateUriAsString()
        {
            var uri = new Uri(Protocol, Host, Path, Params);
            return uri.ToString();
        }

        public void AddProtocol(ProtocolType protocol)
        {
            if (protocol == ProtocolType.Http)
                this.Protocol = Entities.Protocol.Http;
            else
                this.Protocol = Entities.Protocol.Https;
        }

        public void AddHost(string host)
        {
            this.Host = SetComponentEnd(host);
        }

        public void AddPath(string path)
        {
            this.Path = SetComponentEnd(path);
        }

        public void AddParams<T>(T paramsObject)
        {
            TypeInfo info = paramsObject.GetType().GetTypeInfo();
            
        }

        private string SetComponentEnd(string component)
        {
            if (component.EndsWith("/"))
                return component;

            component += "/";

            return component;
        }
    }
}