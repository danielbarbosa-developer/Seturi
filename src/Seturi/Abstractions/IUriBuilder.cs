using Seturi.Entities;

namespace Seturi.Abstractions
{
    public interface IUriBuilder
    {
        Uri GenerateUri();
        Uri GenerateUri(IUriConfig configuration);
    }
}