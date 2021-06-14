using System;

namespace Seturi.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class UriParam : Attribute
    {
        private string ParamName { get; set; }

        public UriParam(string name)
        {
            ParamName = name;
        }
    }
}