//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//namespace BitStore.DbScaffolder.Installers
//{
//    public static class EntityFrameworkInstaller
//    {
//        public static void Install(IServiceCollection services, IConfiguration configuration)
//        {
//            services
//                .AddDbContextPool<Context>(options =>
//                    options.UseSqlServer(configuration.GetConnectionString("PolandPharmacyRx_Orders")));
//        }
//    }
//}
