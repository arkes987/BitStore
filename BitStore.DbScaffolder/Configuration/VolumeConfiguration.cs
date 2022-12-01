using BitStore.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BitStore.DbScaffolder.Configuration
{
    internal class VolumeConfiguration : IEntityTypeConfiguration<Volume>
    {
        public void Configure(EntityTypeBuilder<Volume> builder)
        {
            builder.ToTable("Volume");

            builder.HasKey(e => e.Id);
        }
    }
}
