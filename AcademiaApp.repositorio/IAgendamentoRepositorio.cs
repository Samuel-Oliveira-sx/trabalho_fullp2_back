
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademiaApp.Dominio;

namespace AcademiaApp.Repository
{
    public interface AlunoRepositorio
    {
        Task<Aluno> ObterPorIdAsync(int id);
        Task<IEnumerable<Aluno>> ObterTodosAsync();
        Task AdicionarAsync(Aluno aluno);
        Task AtualizarAsync(Aluno aluno);
        Task RemoverAsync(int id);
        Task<Aluno?> ObterPorNomeAsync(string nome);
    }
}