using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedFlow.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRoleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "doctor");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "intern");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "CanAssignTask", "CanCreateTask", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48d7c3d6-e45a-4e6c-ac3d-ccc66e36717d", true, true, null, "ApplicationRole", "admin", "admin" },
                    { "4fa86f8b-bf99-4cee-a6e5-f4b20a0ee2a0", false, false, null, "ApplicationRole", "intern", "intern" },
                    { "9d13346f-30b6-4584-95ad-6ae33b1bf618", false, true, null, "ApplicationRole", "doctor", "doctor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48d7c3d6-e45a-4e6c-ac3d-ccc66e36717d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fa86f8b-bf99-4cee-a6e5-f4b20a0ee2a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d13346f-30b6-4584-95ad-6ae33b1bf618");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "CanAssignTask", "CanCreateTask", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin", true, true, null, "ApplicationRole", "admin", "admin" },
                    { "doctor", false, true, null, "ApplicationRole", "doctor", "doctor" },
                    { "intern", false, false, null, "ApplicationRole", "intern", "intern" }
                });
        }
    }
}
