# Seturi

Build dynamic URIs

![Build Status](https://github.com/danielbarbosa-developer/Seturi/actions/workflows/dotnet.yml/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/Seturi.svg)](https://nuget.org/packages/Seturi)
[![Nuget](https://img.shields.io/nuget/dt/Seturi.svg)](https://nuget.org/packages/Seturi)

# Version 1.0.0-alpha

We are still testing and do not advise production use of this package. However, we need your help, send your suggestions and let us know what we can improve.

We count on your suggestions and analysis, and if you liked the package, give us a star ⭐... it contributes to our work.

# What is Seturi?

The purpose of this package is to make easier for developers to work with URIs, with objects rather than pure strings. In addition, objectivity and simplicity were placed in this package. 
The most important difference in this package is the possibility to define in your model classes, what properties will be part of the url query as a parameter. You can do this like the example below:

```c#
using Seturi.Attributes;

namespace YourNamespace
{
    public class ExampleModelClass
    {
        [UriParam("name")]
        public string Name { get; set; }
        
        [UriParam("address")]
        public string Address { get; set; }
        
        [UriParam("product")]
        public string Product { get; set; }
        
        [UriParam("productId")]
        public int ProductId { get; set; }
        
        public string AnotherProperty {get; set;}
        
    } 
}
```
After this, using the UriBuilder class you can serialize the model with properties that are marked with the UriParamAttribute and create dynamically your URI with params.

## How to use Seturi?

Use the UriBuilder class to create your URI. See the example as a unit test below:
```c#
using Seturi.Attributes;

namespace YourNamespace
{
     public class Controller
     {
        private ExampleModelClass _params;
        private UriBuilder _builder;
        
        [SetUp]
        public void InitializeTest()
        {
            _params = new ExampleModelClass()
            {
                Name = "Test",
                Address = "TestStreet",
                Product = "Computer",
                ProductId = 1
            };
            
            _builder = new UriBuilder();
        }
        
        //Generate a complete URI with UriBuilder class
        public void UriBuilderGenerateUriAsStringTest()
        {
            #region UriBuilder

            // You can specify the protocol using the ProtocolType enum
            _builder.AddProtocol(ProtocolType.Https);
            _builder.AddHost("www.test.com");
            _builder.AddPath("testing");
            
            // Your class model comes here :)
            // You must specify the method name and then your class model
            _builder.AddQuery<RequestParams>("buy", _params);

            #endregion

            #region Getting Uri completed as string

            var uri = _builder.GenerateUriAsString();

            #endregion

            // The result will be:
            // "https://www.test.com/testing/buy?name=Test&address=TestStreet&product=Computer&productId=1";
            // Now you can only do your http request with the result 
            // or use the URI as you want :) 
        }
     }
}
```
You can get your URI as a object too:

```c#
using Seturi.Attributes;

namespace YourNamespace
{
     public class Controller
     {
        private ExampleModelClass _params;
        private UriBuilder _builder;
        
        [SetUp]
        public void InitializeTest()
        {
            _params = new ExampleModelClass()
            {
                Name = "Test",
                Address = "TestStreet",
                Product = "Computer",
                ProductId = 1
            };
            
            _builder = new UriBuilder();
        }
        
        //Generate a complete URI with UriBuilder class
        public void UriBuilderGenerateUriAsStringTest()
        {
            #region UriBuilder

            // You can specify the protocol using the ProtocolType enum
            _builder.AddProtocol(ProtocolType.Https);
            _builder.AddHost("www.test.com");
            _builder.AddPath("testing");
            
            // Your class model comes here :)
            // You must specify the method name and then your class model
            _builder.AddQuery<RequestParams>("buy", _params);

            #endregion

            #region Getting Uri completed as Uri type

            Uri uri = _builder.GenerateUri();
            
            #endregion
        }
     }
}
```
## Would you like to participate in this project and contribute?

What are you waiting for? 😃

We are open to new ideas! 

Contact the developer, or create a pull request.
Our community need your help to do more powerful code, and help others to solve computational problems.

