using NUnit.Framework;
using Seturi;
using Seturi.Entities;
using SeturiTest.Models;

namespace SeturiTest
{
    [TestFixture]
    public class UriBuilderTest
    {
        private RequestParams _params;
        private UriBuilder _builder;
        
        [SetUp]
        public void InitializeTest()
        {
            _params = new RequestParams()
            {
                Name = "firstTest"
            };
            
            _builder = new UriBuilder();
        }
        [Test]
        [Description("Must generate a complete URI with UriBuilder class")]
        public void UriBuilderGenerateUriAsStringTest()
        {
            #region UriBuilder

            
            _builder.AddProtocol(ProtocolType.Https);
            _builder.AddHost("www.test.com");
            _builder.AddPath("testing");
            _builder.AddParams<RequestParams>("execute", _params);

            #endregion

            #region Getting Uri completed as string

            var uri = _builder.GenerateUriAsString();

            #endregion

            string expectedUri = "https://www.test.com/testing/execute?testName=firstTest";
            Assert.AreEqual(expectedUri, uri);

        }
    }
} 