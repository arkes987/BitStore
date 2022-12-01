using BitStore.Common.Interfaces.Repositories;
using BitStore.Metadata.Context;
using BitStore.Metadata.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BitStore.Metadata.Installers
{
    public static class RepositoryInstaller
    {
        public static IServiceCollection InstallRepositories(this IServiceCollection services)
        {
            services.AddSingleton<MetadataContext>();
            services.AddScoped<IAccessRepository, AccessRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IVolumeRepository, VolumeRepository>();

            return services;
        }
    }
}
