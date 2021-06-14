using System;

namespace Seturi.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class UriParam : Attribute
    {
        public string ParamName { get; set; }
        public object Value { get; set; }

        public UriParam(string name)
        {
            ParamName = name;
        }
    }
}