using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scheduling.Migrations
{
    /// <inheritdoc />
    public partial class EntityEmpresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Barbeiros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_EmpresaId",
                table: "Servicos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EmpresaId",
                table: "Clientes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Barbeiros_EmpresaId",
                table: "Barbeiros",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_EmpresaId",
                table: "Agendamentos",
                column: "EmpresaId");

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
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_EmpresaId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_EmpresaId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Barbeiros_EmpresaId",
                table: "Barbeiros");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_EmpresaId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Barbeiros");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Agendamentos");
        }
    }
}
