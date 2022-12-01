using BitStore.Common.Models;
using BitStore.DbScaffolder.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BitStore.DbScaffolder
{
    public class BitStoreContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public BitStoreContext()
        {

        }
        public BitStoreContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=postgres;Trust Server Certificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccessConfiguration());
            modelBuilder.ApplyConfiguration(new VolumeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
