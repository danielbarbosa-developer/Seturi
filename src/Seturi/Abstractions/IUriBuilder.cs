using Seturi.Entities;

namespace Seturi.Abstractions
{
    public interface IUriBuilder
    {
        Uri GenerateUri();
        string GenerateUriAsString();
        void AddProtocol(ProtocolType protocol);
        void AddHost(string host);
        void AddPath(string path);
        void AddQuery<T>(string methodName, T paramsObject);
    }
}