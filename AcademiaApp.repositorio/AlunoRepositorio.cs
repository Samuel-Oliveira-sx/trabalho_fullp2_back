
using Microsoft.EntityFrameworkCore;
using AcademiaApp.Dominio;

namespace AcademiaApp.Repositorio
{
    public class AppDbContext: DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options) { }
    }
}