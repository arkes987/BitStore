using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedLockNet;
using RedLockNet.SERedis;
using RedLockNet.SERedis.Configuration;
using StackExchange.Redis;

namespace BitStore.Cache.Installers
{
    public static class RedLockInstaller
    {
        public static IServiceCollection InstallRedLock(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionMultiplexer = ConnectionMultiplexer.Connect(configuration["Redis:Url"]);

            var multiplexers = new List<RedLockMultiplexer>
            {
                connectionMultiplexer
            };

            services.AddScoped<IDistributedLockFactory, RedLockFactory>(
                x => RedLockFactory.Create(multiplexers));

            return services;
        }
    }
}
