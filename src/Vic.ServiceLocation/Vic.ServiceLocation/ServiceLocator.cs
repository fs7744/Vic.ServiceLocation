using System;

namespace Vic.ServiceLocation
{
    /// <summary>
    /// Simple service locator depend on Microsoft.Extensions.DependencyInjection.
    /// </summary>
    public class ServiceLocator : IServiceProvider
    {
        /// <summary>
        /// Current ServiceLocator Instance.
        /// </summary>
        public static readonly ServiceLocator Current = new ServiceLocator();

        private IServiceProvider serviceProvider;

        /// <summary>
        /// set actual ServiceProvider to Current ServiceLocator Instance.
        /// </summary>
        /// <param name="provider"></param>
        /// <returns>Current ServiceLocator Instance.</returns>
        public ServiceLocator SetServiceProvider(IServiceProvider provider)
        {
            serviceProvider = provider;
            return this;
        }

        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>A service object of type serviceType. -or- null if there is no service object of type serviceType.</returns>
        public object GetService(Type serviceType)
        {
            return serviceProvider.GetService(serviceType);
        }
    }
}