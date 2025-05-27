
using AcademiaApp.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaApp.Dominio.Servicos
{
    public interface IAlunoServico
    {
        Task CadastrarAlunoAsync(Aluno aluno);
        Task<Aluno?> ObterPorIdAsync(int? id); // Agora o ID é opcional
        Task<IEnumerable<Aluno>> ObterTodosAsync();
        Task AtualizarAlunoAsync(Aluno aluno);
        Task RemoverAlunoAsync(int id);
    }
}