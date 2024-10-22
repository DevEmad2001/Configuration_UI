using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GUI_Adtech_V2.Migrations
{
    /// <inheritdoc />
    public partial class AddAdtechTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdtecComponents",
                columns: table => new
                {
                    ComponentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdtecComponents", x => x.ComponentID);
                });

            migrationBuilder.CreateTable(
                name: "AdtechConfigs",
                columns: table => new
                {
                    Seq_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParameterValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComponentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdtechConfigs", x => x.Seq_Id);
                });

            migrationBuilder.CreateTable(
                name: "AdtechSystems",
                columns: table => new
                {
                    SystemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdtechSystems", x => x.SystemID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdtecComponents");

            migrationBuilder.DropTable(
                name: "AdtechConfigs");

            migrationBuilder.DropTable(
                name: "AdtechSystems");
        }
    }
}
