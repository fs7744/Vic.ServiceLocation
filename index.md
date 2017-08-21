# Vic.ServiceLocation
Simple service locator depend on Microsoft.Extensions.DependencyInjection

## Quick start

### Install package

* Package Manager

```
Install-Package Vic.ServiceLocation -Version 0.1.0
```
* .NET CLI

```
dotnet add package Vic.ServiceLocation --version 0.1.0
```

### Simple use example

``` csharp
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Vic.ServiceLocation.Test
{
    public interface ITest
    {
        string Data { get; }
    }

    public class TestData : ITest
    {
        public string Data => "TestDataVic";
    }

    public class ServiceLocationTest
    {
        public ServiceLocationTest()
        {
            var privoder = new ServiceCollection()
                .AddTransient<ITest, TestData>()
                .UseServiceLocator()  // Required, set current ServiceLocator's service descriptors.
                .BuildServiceProvider();
            privoder.GetRequiredService<ServiceLocator>(); // Required, because the DependencyInjection is Lazy, so we must call once before we use
        }

        [Fact(DisplayName = "GetITestInstanceIsTestData")]
        public void Test()
        {
            var instance = ServiceLocator.Current.GetService<ITest>();
            Assert.Equal("TestDataVic", instance.Data);
            var instance2 = ServiceLocator.Current.GetService<ITest>();
            Assert.Equal("TestDataVic", instance2.Data);
            Assert.NotSame(instance, instance2);
        }
    }
}
```

### api doc

Main api doc please see 

[https://fs7744.github.io/Vic.ServiceLocation/index.html](https://fs7744.github.io/Vic.ServiceLocation/index.html)