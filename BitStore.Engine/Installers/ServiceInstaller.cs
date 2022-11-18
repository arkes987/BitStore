using BitStore.Common.Interfaces.Services;
using BitStore.Engine.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BitStore.Engine.Installers
{
    public static class ServiceInstaller
    {
        public static void InstallServices(IServiceCollection services)
        {
            services.AddScoped<IObjectService, ObjectService>();
        }
    }
}
