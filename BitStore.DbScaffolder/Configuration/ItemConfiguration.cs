using BitStore.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BitStore.DbScaffolder.Configuration
{
    internal class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable(Item.TableName);

            builder.HasKey(e => e.Id);

            builder.Property(x => x.Size)
                .IsRequired(true);

            builder.Property(x => x.Name)
                .IsRequired(true);

            builder.Property(x => x.Extension)
                .IsRequired(true);

            builder.Property(x => x.AbsolutePath)
                .IsRequired(true);

            builder.Property(x => x.CreatedAt)
                .IsRequired(true);

            builder.HasOne(x => x.Volume)
                .WithMany(x => x.Items)
                .IsRequired();
        }
    }
}
