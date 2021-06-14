using Seturi.Attributes;

namespace SeturiTest.Models
{
    public class RequestParams
    {
        [UriParam("testName")]
        public string Name { get; set; }
    } 
}