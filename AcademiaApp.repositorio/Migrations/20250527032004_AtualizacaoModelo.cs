using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaApp.repositorio.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanosAtivos",
                table: "Alunos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlanosAtivos",
                table: "Alunos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
