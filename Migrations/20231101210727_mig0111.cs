using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fut360.Migrations
{
    /// <inheritdoc />
    public partial class mig0111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemLocal",
                table: "Local");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "AgendamentoModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "AgendamentoModel");

            migrationBuilder.AddColumn<string>(
                name: "ImagemLocal",
                table: "Local",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
