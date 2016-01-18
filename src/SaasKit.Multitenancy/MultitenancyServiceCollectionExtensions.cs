using SaasKit.Multitenancy;
using SaasKit.Multitenancy.Internal;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MultitenancyServiceCollectionExtensions
    {
        public static IServiceCollection AddMultitenancy<TTenant, TResolver>(this IServiceCollection services) 
            where TResolver : class, ITenantResolver<TTenant>
        {
            Ensure.Argument.NotNull(services, nameof(services));

            services.AddScoped<ITenantResolver<TTenant>, TResolver>();
            services.AddScoped<ITenantContextAccessor<TTenant>, HttpContextTenantContextAccessor<TTenant>>();
            services.AddScoped<ITenantAccessor<TTenant>, HttpContextTenantAccessor<TTenant>>();

            // Ensure caching is available for caching resolvers
            services.AddCaching();

            return services;
        }
    }
}
