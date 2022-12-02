using BitStore.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BitStore.DbScaffolder.Configuration
{
    internal class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("items");

            builder.HasKey(e => e.Id);

            builder.HasOne(x => x.Volume)
                .WithMany(x => x.Items)
                .IsRequired();
        }
    }
}
