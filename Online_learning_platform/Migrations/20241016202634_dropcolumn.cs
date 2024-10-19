using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_learning_platform.Migrations
{
    /// <inheritdoc />
    public partial class dropcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "lesson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
