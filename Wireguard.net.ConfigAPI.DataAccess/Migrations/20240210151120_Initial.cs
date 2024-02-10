using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wireguard.net.ConfigAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrivateKey = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PublicKey = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PresharedKey = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigNodes",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigNodes", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "PeerEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigFileId = table.Column<int>(type: "int", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PresharedKey = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PublicKey = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeerEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeerEntries_ConfigFiles_ConfigFileId",
                        column: x => x.ConfigFileId,
                        principalTable: "ConfigFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeerEntries_ConfigFileId",
                table: "PeerEntries",
                column: "ConfigFileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigNodes");

            migrationBuilder.DropTable(
                name: "PeerEntries");

            migrationBuilder.DropTable(
                name: "ConfigFiles");
        }
    }
}
