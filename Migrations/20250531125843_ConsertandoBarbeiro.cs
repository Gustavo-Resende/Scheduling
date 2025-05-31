using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scheduling.Migrations
{
    /// <inheritdoc />
    public partial class ConsertandoBarbeiro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Especialidade",
                table: "Barbeiros");

            migrationBuilder.RenameColumn(
                name: "endereco",
                table: "Empresas",
                newName: "Endereco");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Clientes",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Barbeiros",
                newName: "Cpf");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Barbeiros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Agendamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Barbeiros");

            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Empresas",
                newName: "endereco");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Clientes",
                newName: "cpf");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Barbeiros",
                newName: "cpf");

            migrationBuilder.AddColumn<string>(
                name: "Especialidade",
                table: "Barbeiros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Agendamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
