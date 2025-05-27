
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AcademiaApp.Repositorio
{
    public class AcademiaDbContextFactory : IDesignTimeDbContextFactory<AcademiaDbContext>
    {
        public AcademiaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AcademiaDbContext>();
            optionsBuilder.UseSqlite("Data Source=meubanco.db");

            return new AcademiaDbContext(optionsBuilder.Options);
        }
    }
}