using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fut360.Migrations
{
    /// <inheritdoc />
    public partial class _30102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemLocal",
                table: "Local",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemLocal",
                table: "Local");
        }
    }
}
