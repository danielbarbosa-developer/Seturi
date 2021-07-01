using System.Collections.Generic;
using System.Reflection;
using Seturi.Attributes;
using Seturi.Exceptions;

namespace Seturi.Services
{
    internal sealed class ReflectionServices
    {
        private List<UriParam> ParamsList;
        public ReflectionServices()
        {
            this.ParamsList = new List<UriParam>();
        }
        public List<UriParam> GetAttributeFields(System.Type type, object obj)
        {
            ParamsList.Clear();
            
            foreach (var info in type.GetRuntimeProperties())
            {
                foreach (Attributes.UriParam uriAttribute in info.GetCustomAttributes(typeof(Attributes.UriParam), false))
                {
                    uriAttribute.Value = info.GetValue(obj, null);
                    
                    if(uriAttribute.Value == null)
                        continue;

                    if (uriAttribute.Value.GetType() == typeof(IEnumerable<>) ||
                        uriAttribute.Value.GetType() == typeof(IList<>))
                        throw new InvalidParamsException($"Property cannot be of type: {uriAttribute.Value.GetType()}");
                    
                    
                    ParamsList.Add(uriAttribute);
                }
            }
            return ParamsList;
        }
    }
}