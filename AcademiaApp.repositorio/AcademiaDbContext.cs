
using Microsoft.EntityFrameworkCore;
using AcademiaApp.Dominio;

namespace AcademiaApp.Repositorio
{
    public class AcademiaDbContext : DbContext
    {
        public AcademiaDbContext(DbContextOptions<AcademiaDbContext> options) : base(options) { }

        // Registro das entidades no banco de dados
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais de mapeamento, se necessário
        }
    }
}