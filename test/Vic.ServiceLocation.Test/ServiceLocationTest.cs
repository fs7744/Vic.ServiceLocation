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