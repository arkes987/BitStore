using BitStore.Common.Interfaces.EventBus;
using Microsoft.Extensions.DependencyInjection;

namespace BitStore.AnalyticsEngine.Installers
{
    public static class EventBusInstaller
    {
        public static IServiceCollection InstallEventBus(this IServiceCollection services)
        {
            services.AddScoped<IEventBus, EventBus.EventBus>();

            return services;
        }
    }
}
