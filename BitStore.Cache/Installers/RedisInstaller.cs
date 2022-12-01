using BitStore.Common.Interfaces.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BitStore.Cache.Installers
{
    public static class RedisInstaller
    {
        public static void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Url"];
                options.InstanceName = "BitStore";
            });

            services.AddSingleton<IRedisLock, RedisLock>();
            services.AddSingleton<IRedisCache, RedisCache>();
        }
    }
}
