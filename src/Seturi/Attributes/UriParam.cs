using System;

namespace Seturi.Attributes
{
    /// <summary>
    /// A attribute used to define what property of your model can be serialized as a URI param in its query 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class UriParam : Attribute
    {
        public string ParamName { get; set; }
        public object Value { get; set; }

        /// <summary>
        /// A attribute used to define what property of your model can be serialized as a URI param in its query 
        /// </summary>
        /// <param name="name">The property name that will be used when serialized in the query</param>
        public UriParam(string name)
        {
            ParamName = name;
        }
    }
}