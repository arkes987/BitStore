using BitStore.Common.Interfaces.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BitStore.Cache.Installers
{
    public static class RedisInstaller
    {
        public static IServiceCollection InstallRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Url"];
                options.InstanceName = "BitStore";
            });

            services.AddScoped<IRedisLock, RedisLock>();
            services.AddScoped<IRedisCache, RedisCache>();

            return services;
        }
    }
}
