using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GUI_Adtech.Migrations
{
    /// <inheritdoc />
    public partial class AddComponentNameToAdtechConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComponentName",
                table: "Configs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComponentName",
                table: "Configs");
        }
    }
}
