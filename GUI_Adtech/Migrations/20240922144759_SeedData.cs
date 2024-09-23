using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GUI_Adtech.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration 
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Systems",
                columns: new[] { "SystemID", "SystemName" },
                values: new object[,]
                {
                    { 1, "HES" },
                    { 2, "GIS" },
                    { 3, "SCADA" },
                    { 4, "SINCAL" },
                    { 5, "Core" }
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "ComponentID", "ComponentName", "SystemID" },
                values: new object[,]
                {
                    { 1, "MeterInstallation", 1 },
                    { 2, "DailyReading", 1 },
                    { 3, "NetworkGISNode", 2 }
                });

            migrationBuilder.InsertData(
                table: "Configs",
                columns: new[] { "Seq_Id", "ComponentID", "ModifiesDate", "ParameterName", "ParameterValue" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 22, 17, 47, 58, 341, DateTimeKind.Local).AddTicks(6279), "ServiceURL", "http://example.com" },
                    { 2, 1, new DateTime(2024, 9, 22, 17, 47, 58, 345, DateTimeKind.Local).AddTicks(6279), "LogfilePath", "C:/logs" },
                    { 3, 3, new DateTime(2024, 9, 22, 17, 47, 58, 345, DateTimeKind.Local).AddTicks(6296), "ServiceURL", "http://gis.example.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "ComponentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Configs",
                keyColumn: "Seq_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Configs",
                keyColumn: "Seq_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Configs",
                keyColumn: "Seq_Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Systems",
                keyColumn: "SystemID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Systems",
                keyColumn: "SystemID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Systems",
                keyColumn: "SystemID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "ComponentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "ComponentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Systems",
                keyColumn: "SystemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Systems",
                keyColumn: "SystemID",
                keyValue: 2);
        }
    }
}
