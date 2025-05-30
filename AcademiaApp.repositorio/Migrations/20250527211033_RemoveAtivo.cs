using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaApp.repositorio.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAtivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Alunos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Alunos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
