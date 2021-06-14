using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Seturi.Abstractions;
using Seturi.Attributes;
using Seturi.Entities;
using Seturi.Services;
using Uri = Seturi.Entities.Uri;

namespace Seturi
{
    public class UriBuilder : IUriBuilder
    {
        private  string Protocol { get; set; }
        
        private  string Host { get; set; }
        
        private  string Path { get; set; }
        
        private  string Params { get; set; }

        private readonly ReflectionServices _reflection;

        public UriBuilder()
        {
            _reflection = new ReflectionServices();
        }
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

        public void AddParams<T>(string methodName, T paramsObject)
        {
            var type = paramsObject.GetType();
            var parameters = _reflection.GetAttributeFields(type, paramsObject);

            Params = methodName + GenerateParamsString(parameters);

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
    }
}