using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoDeExames.Migrations
{
    public partial class isActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "SavePacientViewModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "SavePacientViewModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "SavePacientViewModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "SavePacientViewModel",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Pacient",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Doctor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Clinic",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SaveClinicViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstPhone = table.Column<string>(nullable: false),
                    SecondPhone = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveClinicViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaveDoctorViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Crm = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveDoctorViewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaveClinicViewModel");

            migrationBuilder.DropTable(
                name: "SaveDoctorViewModel");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SavePacientViewModel");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Pacient");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Clinic");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "SavePacientViewModel",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "SavePacientViewModel",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "SavePacientViewModel",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
