using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedFlow.Web.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "148fda72-89c8-4aee-8372-6bff301a8267", null, "admin", "admin" },
                    { "440fbf82-f179-4323-9033-506dd58049fa", null, "intern", "intern" },
                    { "886373b7-db3d-4239-8e9a-8903d8134a66", null, "doctor", "doctor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "148fda72-89c8-4aee-8372-6bff301a8267");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "440fbf82-f179-4323-9033-506dd58049fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "886373b7-db3d-4239-8e9a-8903d8134a66");
        }
    }
}
