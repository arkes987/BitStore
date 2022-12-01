using BitStore.Common.Interfaces.Services;
using BitStore.Engine.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BitStore.Engine.Installers
{
    public static class ServiceInstaller
    {
        public static void Install(IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IVolumeService, VolumeService>();
        }
    }
}
