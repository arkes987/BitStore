using BitStore.Common.Interfaces.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BitStore.Cache.Installers
{
    public static class RedisInstaller
    {
        public static void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Url"];
                options.InstanceName = "BitStore";
            });

            services.AddSingleton<IRedisLock, RedisLock>();
        }
    }
}
