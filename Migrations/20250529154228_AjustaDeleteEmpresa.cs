using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scheduling.Migrations
{
    /// <inheritdoc />
    public partial class AjustaDeleteEmpresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Empresas_EmpresaId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Barbeiros_Empresas_EmpresaId",
                table: "Barbeiros");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Empresas_EmpresaId",
                table: "Servicos");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Empresas_EmpresaId",
                table: "Agendamentos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Barbeiros_Empresas_EmpresaId",
                table: "Barbeiros",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Empresas_EmpresaId",
                table: "Servicos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Empresas_EmpresaId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Barbeiros_Empresas_EmpresaId",
                table: "Barbeiros");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Empresas_EmpresaId",
                table: "Servicos");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Empresas_EmpresaId",
                table: "Agendamentos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Barbeiros_Empresas_EmpresaId",
                table: "Barbeiros",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Empresas_EmpresaId",
                table: "Servicos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
