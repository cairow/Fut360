using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fut360.Migrations
{
    /// <inheritdoc />
    public partial class HorarioModelChanging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data",
                table: "Horarios");

            migrationBuilder.RenameColumn(
                name: "hora_inicio",
                table: "Horarios",
                newName: "Hora_inicio");

            migrationBuilder.RenameColumn(
                name: "hora_fim",
                table: "Horarios",
                newName: "Hora_fim");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Hora_inicio",
                table: "Horarios",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Hora_fim",
                table: "Horarios",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Horarios",
                columns: new[] { "Id", "Hora_fim", "Hora_inicio" },
                values: new object[,]
                {
                    { 6, new TimeSpan(0, 6, 30, 0, 0), new TimeSpan(0, 6, 0, 0, 0) },
                    { 7, new TimeSpan(0, 7, 30, 0, 0), new TimeSpan(0, 7, 0, 0, 0) },
                    { 8, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 9, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 10, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 11, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 11, 0, 0, 0) },
                    { 12, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 12, 0, 0, 0) },
                    { 13, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 14, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { 15, new TimeSpan(0, 15, 30, 0, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { 16, new TimeSpan(0, 16, 30, 0, 0), new TimeSpan(0, 16, 0, 0, 0) },
                    { 17, new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 17, 0, 0, 0) },
                    { 18, new TimeSpan(0, 18, 30, 0, 0), new TimeSpan(0, 18, 0, 0, 0) },
                    { 19, new TimeSpan(0, 19, 30, 0, 0), new TimeSpan(0, 19, 0, 0, 0) },
                    { 20, new TimeSpan(0, 20, 30, 0, 0), new TimeSpan(0, 20, 0, 0, 0) },
                    { 21, new TimeSpan(0, 21, 30, 0, 0), new TimeSpan(0, 21, 0, 0, 0) },
                    { 22, new TimeSpan(0, 22, 30, 0, 0), new TimeSpan(0, 22, 0, 0, 0) },
                    { 23, new TimeSpan(0, 23, 30, 0, 0), new TimeSpan(0, 23, 0, 0, 0) },
                    { 24, new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 23, 0, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.RenameColumn(
                name: "Hora_inicio",
                table: "Horarios",
                newName: "hora_inicio");

            migrationBuilder.RenameColumn(
                name: "Hora_fim",
                table: "Horarios",
                newName: "hora_fim");

            migrationBuilder.AlterColumn<DateTime>(
                name: "hora_inicio",
                table: "Horarios",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "hora_fim",
                table: "Horarios",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<DateTime>(
                name: "data",
                table: "Horarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
