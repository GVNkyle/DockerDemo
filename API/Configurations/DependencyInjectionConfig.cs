
using API._Repositories.Interface;
using API._Repositories.Repositories;
using API._Services.Interface;
using API._Services.Services;

namespace API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //RepositoryAccessor
            services.AddScoped<IRepositoryAccessor, RepositoryAccessor>();

            //Service
            services.AddScoped<IAddressService, AddressService>();
        }
    }
}