using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Online_learning_platform.Migrations
{
    /// <inheritdoc />
    public partial class role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64555fa5-b38d-4355-9508-02d444fc3edd", "a4da0b3c-5f78-4941-9dae-190123c30242", "User", "user" },
                    { "871baf57-2f12-4a94-926c-e365d65ce27a", "81ad9c55-b327-4009-b3b3-54fe67a45e2b", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64555fa5-b38d-4355-9508-02d444fc3edd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "871baf57-2f12-4a94-926c-e365d65ce27a");
        }
    }
}
