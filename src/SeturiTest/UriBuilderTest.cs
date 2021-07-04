using NUnit.Framework;
using Seturi;
using Seturi.Entities;
using Seturi.Exceptions;
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
            _builder.AddQuery<RequestParams>("execute", _params);

            #endregion

            #region Getting Uri completed as string

            var uri = _builder.GenerateUriAsString();

            #endregion

            string expectedUri = "https://www.test.com/testing/execute?testName=firstTest";
            Assert.AreEqual(expectedUri, uri);

        }
        
        [Test]
        [Description("Must throw InvalidHostException")]
        public void UriBuilderMustThrowHostException()
        {
            #region UriBuilder

            _builder.AddProtocol(ProtocolType.Https);
            Assert.That(() => _builder.AddHost(""), 
                Throws.TypeOf<InvalidHostException>());
            
            _builder.AddPath("testing");
            _builder.AddQuery<RequestParams>("execute", _params);

            #endregion
        }
        
        [Test]
        [Description("Must throw InvalidPathException")]
        public void UriBuilderMustThrowPathException()
        {
            #region UriBuilder

            _builder.AddProtocol(ProtocolType.Https);
            _builder.AddHost("www.test.com");
            
            Assert.That(() => _builder.AddPath(""), 
                Throws.TypeOf<InvalidPathException>());
            
            _builder.AddQuery<RequestParams>("execute", _params);

            #endregion
        }
        [Test]
        [Description("Must throw UriPropertyNotFoundException")]
        public void UriBuilderMustThrowUriPropertyNotFoundExceptionWhenProtocolNotDefined()
        {
            // Protocol must to be define, but wasn't :(
            // _builder.AddProtocol(ProtocolType.Https);
            
            _builder.AddHost("www.test.com");
            
            _builder.AddPath("testing");
            _builder.AddQuery<RequestParams>("execute", _params);
            
            Assert.That(() => _builder.GenerateUri(), 
                Throws.TypeOf<UriPropertyNotFoundException>());
           
        }
        
        [Test]
        [Description("Must throw UriPropertyNotFoundException")]
        public void UriBuilderMustThrowUriPropertyNotFoundExceptionWhenHostNotDefined()
        {
            _builder.AddProtocol(ProtocolType.Https);
            
            // Host must to be define, but wasn't :(
            // _builder.AddHost("www.test.com");
            
            _builder.AddPath("testing");
            _builder.AddQuery<RequestParams>("execute", _params);
            
            Assert.That(() => _builder.GenerateUri(), 
                Throws.TypeOf<UriPropertyNotFoundException>());
           
        }
        
    }
} 