using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_learning_platform.Migrations
{
    /// <inheritdoc />
    public partial class Creat_Description_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "lessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "lessons");
        }
    }
}
