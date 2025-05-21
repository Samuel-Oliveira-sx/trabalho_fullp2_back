
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademiaApp.Dominio;

namespace AcademiaApp.Repository
{
    public interface IAlunoRepositorio
    {
        Task<Aluno> ObterPorIdAsync(int id);
        Task<IEnumerable<Aluno>> ObterTodosAsync();
        Task AdicionarAsync(Aluno aluno);
        Task AtualizarAsync(Aluno aluno);
        Task RemoverAsync(int id);
    }
}