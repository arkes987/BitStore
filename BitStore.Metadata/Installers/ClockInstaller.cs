using BitStore.Common.Interfaces.Time;
using BitStore.Metadata.Time;
using Microsoft.Extensions.DependencyInjection;

namespace BitStore.Metadata.Installers
{
    public static class ClockInstaller
    {
        public static IServiceCollection InstallClock(this IServiceCollection services)
        {
            services.AddScoped<IClock, UtcClock>();

            return services;
        }
    }
}
