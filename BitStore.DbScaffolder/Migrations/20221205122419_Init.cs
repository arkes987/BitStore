using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitStore.DbScaffolder.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "access",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LastAccessAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Reads = table.Column<long>(type: "bigint", nullable: false),
                    Writes = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_access", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "volumes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Host = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Share = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    FreeSpace = table.Column<long>(type: "bigint", nullable: false),
                    UsedSpace = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_volumes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Extension = table.Column<string>(type: "text", nullable: false),
                    AbsolutePath = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VolumeId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccessId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_items_access_AccessId",
                        column: x => x.AccessId,
                        principalTable: "access",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_items_volumes_VolumeId",
                        column: x => x.VolumeId,
                        principalTable: "volumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_items_AccessId",
                table: "items",
                column: "AccessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_items_VolumeId",
                table: "items",
                column: "VolumeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "access");

            migrationBuilder.DropTable(
                name: "volumes");
        }
    }
}
