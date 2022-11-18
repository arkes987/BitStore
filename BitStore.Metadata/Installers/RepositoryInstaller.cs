using BitStore.Common.Interfaces.Repositories;
using BitStore.Metadata.Context;
using BitStore.Metadata.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BitStore.Metadata.Installers
{
    public static class RepositoryInstaller
    {
        public static void InstallServices(IServiceCollection services)
        {
            services.AddSingleton<MetadataContext>();
            services.AddScoped<IAccessRepository, AccessRepository>();
            services.AddScoped<IObjectRepository, ObjectRepository>();
            services.AddScoped<IVolumeRepository, VolumeRepository>();
        }
    }
}
