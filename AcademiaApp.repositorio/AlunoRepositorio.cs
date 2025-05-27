
using Microsoft.EntityFrameworkCore;
using AcademiaApp.Dominio;

namespace AcademiaApp.Repositorio
{
    public class AlunoRepositorio
    {
        private readonly AcademiaDbContext _context;

        public AlunoRepositorio(AcademiaDbContext context)
        {
            _context = context;
        }

        // Método para obter todos os alunos
        public async Task<List<Aluno>> ObterTodosAsync()
        {
            return await _context.Alunos.ToListAsync();
        }

        // Método para obter um aluno pelo ID
        public async Task<Aluno?> ObterPorIdAsync(int id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        // Método para adicionar um aluno
        public async Task AdicionarAsync(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }

        // Método para atualizar um aluno
        public async Task AtualizarAsync(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();
        }

        // Método para remover um aluno pelo ID
        public async Task RemoverAsync(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
            }
        }

        // Método para obter um aluno pelo nome
        public async Task<Aluno?> ObterPorNomeAsync(string nome)
        {
            return await _context.Alunos.FirstOrDefaultAsync(a => a.Nome == nome);
        }
    }
}