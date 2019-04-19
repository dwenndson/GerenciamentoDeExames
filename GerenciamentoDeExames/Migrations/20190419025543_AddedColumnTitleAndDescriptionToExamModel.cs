using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoDeExames.Migrations
{
    public partial class AddedColumnTitleAndDescriptionToExamModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Exam",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Exam",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClinicViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstPhone = table.Column<string>(nullable: true),
                    SecondPhone = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicViewModel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ClinicId = table.Column<Guid>(nullable: true),
                    PacientId = table.Column<Guid>(nullable: true),
                    ExamPath = table.Column<string>(nullable: true),
                    DataEnviado = table.Column<DateTime>(nullable: false),
                    DataConfirmado = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamViewModel_ClinicViewModel_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "ClinicViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamViewModel_PacientViewModel_PacientId",
                        column: x => x.PacientId,
                        principalTable: "PacientViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaveExamViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PacientId = table.Column<Guid>(nullable: false),
                    ClinicId = table.Column<Guid>(nullable: false),
                    DataEnviado = table.Column<DateTime>(nullable: false),
                    DataConfirmado = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveExamViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaveExamViewModel_ClinicViewModel_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "ClinicViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaveExamViewModel_PacientViewModel_PacientId",
                        column: x => x.PacientId,
                        principalTable: "PacientViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicViewModel_UserId",
                table: "ClinicViewModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamViewModel_ClinicId",
                table: "ExamViewModel",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamViewModel_PacientId",
                table: "ExamViewModel",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_SaveExamViewModel_ClinicId",
                table: "SaveExamViewModel",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_SaveExamViewModel_PacientId",
                table: "SaveExamViewModel",
                column: "PacientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamViewModel");

            migrationBuilder.DropTable(
                name: "SaveExamViewModel");

            migrationBuilder.DropTable(
                name: "ClinicViewModel");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Exam");
        }
    }
}
