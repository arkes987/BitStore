using BitStore.Common.Models;
using BitStore.DbScaffolder.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BitStore.DbScaffolder
{
    public class BitStoreContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public BitStoreContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration["Metadata:ConnectionString"]);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccessConfiguration());
            modelBuilder.ApplyConfiguration(new VolumeConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
