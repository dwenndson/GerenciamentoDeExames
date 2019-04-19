using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoDeExames.Migrations
{
    public partial class maisuma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PacientViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacientViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacientViewModel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SavePacientViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavePacientViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PacientViewModel_UserId",
                table: "PacientViewModel",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacientViewModel");

            migrationBuilder.DropTable(
                name: "SavePacientViewModel");
        }
    }
}
