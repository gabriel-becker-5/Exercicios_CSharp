using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aula_MVC_04_Exercicios.Migrations
{
    /// <inheritdoc />
    public partial class InclusaoTelefoneAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Alunos",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Alunos");
        }
    }
}
