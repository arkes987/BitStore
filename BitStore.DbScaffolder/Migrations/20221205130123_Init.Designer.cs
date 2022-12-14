// <auto-generated />
using System;
using BitStore.DbScaffolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BitStore.DbScaffolder.Migrations
{
    [DbContext(typeof(BitStoreContext))]
    [Migration("20221205130123_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BitStore.Common.Models.Access", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastAccessAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Reads")
                        .HasColumnType("bigint");

                    b.Property<long>("Writes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("access", (string)null);
                });

            modelBuilder.Entity("BitStore.Common.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AbsolutePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("AccessId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<Guid>("VolumeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AccessId")
                        .IsUnique();

                    b.HasIndex("VolumeId");

                    b.ToTable("items", (string)null);
                });

            modelBuilder.Entity("BitStore.Common.Models.Volume", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("FreeSpace")
                        .HasColumnType("bigint");

                    b.Property<string>("Host")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Share")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<long>("UsedSpace")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("volumes", (string)null);
                });

            modelBuilder.Entity("BitStore.Common.Models.Item", b =>
                {
                    b.HasOne("BitStore.Common.Models.Access", "Access")
                        .WithOne("Item")
                        .HasForeignKey("BitStore.Common.Models.Item", "AccessId");

                    b.HasOne("BitStore.Common.Models.Volume", "Volume")
                        .WithMany("Items")
                        .HasForeignKey("VolumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Access");

                    b.Navigation("Volume");
                });

            modelBuilder.Entity("BitStore.Common.Models.Access", b =>
                {
                    b.Navigation("Item")
                        .IsRequired();
                });

            modelBuilder.Entity("BitStore.Common.Models.Volume", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
