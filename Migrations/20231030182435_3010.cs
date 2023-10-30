using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fut360.Migrations
{
    /// <inheritdoc />
    public partial class _3010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgendamentoModel_Local_LocalId",
                table: "AgendamentoModel");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AgendamentoModel");

            migrationBuilder.RenameColumn(
                name: "LocalId",
                table: "AgendamentoModel",
                newName: "localModelId");

            migrationBuilder.RenameIndex(
                name: "IX_AgendamentoModel_LocalId",
                table: "AgendamentoModel",
                newName: "IX_AgendamentoModel_localModelId");

            migrationBuilder.AddColumn<string>(
                name: "userModelId",
                table: "AgendamentoModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoModel_userModelId",
                table: "AgendamentoModel",
                column: "userModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgendamentoModel_AspNetUsers_userModelId",
                table: "AgendamentoModel",
                column: "userModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AgendamentoModel_Local_localModelId",
                table: "AgendamentoModel",
                column: "localModelId",
                principalTable: "Local",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgendamentoModel_AspNetUsers_userModelId",
                table: "AgendamentoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AgendamentoModel_Local_localModelId",
                table: "AgendamentoModel");

            migrationBuilder.DropIndex(
                name: "IX_AgendamentoModel_userModelId",
                table: "AgendamentoModel");

            migrationBuilder.DropColumn(
                name: "userModelId",
                table: "AgendamentoModel");

            migrationBuilder.RenameColumn(
                name: "localModelId",
                table: "AgendamentoModel",
                newName: "LocalId");

            migrationBuilder.RenameIndex(
                name: "IX_AgendamentoModel_localModelId",
                table: "AgendamentoModel",
                newName: "IX_AgendamentoModel_LocalId");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AgendamentoModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_AgendamentoModel_Local_LocalId",
                table: "AgendamentoModel",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
