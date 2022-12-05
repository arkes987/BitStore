using BitStore.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BitStore.DbScaffolder.Configuration
{
    internal class AccessConfiguration : IEntityTypeConfiguration<Access>
    {
        public void Configure(EntityTypeBuilder<Access> builder)
        {
            builder.ToTable("access");

            builder.HasKey(e => e.Id);

            builder.HasOne(x => x.Item)
                .WithOne(x => x.Access)
                .HasForeignKey<Item>(x => x.AccessId)
                .IsRequired(false);
        }
    }
}
