using BitStore.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BitStore.DbScaffolder.Configuration
{
    internal class VolumeConfiguration : IEntityTypeConfiguration<Volume>
    {
        public void Configure(EntityTypeBuilder<Volume> builder)
        {
            builder.ToTable(Volume.TableName);

            builder.HasKey(e => e.Id);

            builder.Property(x => x.Host)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(x => x.FreeSpace)
                .IsRequired(true);

            builder.Property(x => x.UsedSpace)
                .IsRequired(true);

            builder.Property(x => x.Share)
                .IsRequired(true)
                .HasMaxLength(150);
        }
    }
}
