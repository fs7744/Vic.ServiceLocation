using Vic.ServiceLocation;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Service Locator Extensions Methods
    /// </summary>
    public static class ServiceLocatorExtensions
    {
        /// <summary>
        /// set current ServiceLocator's service descriptors.
        /// </summary>
        /// <param name="services">a collection of service descriptors.</param>
        /// <returns>a collection of service descriptors.</returns>
        public static IServiceCollection UseServiceLocator(this IServiceCollection services)
        {
            return services.AddSingleton(i => ServiceLocator.Current.SetServiceProvider(i));
        }
    }
}