
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademiaApp.Dominio;

namespace AcademiaApp.Servico
{
    public interface IProfessorServico
    {
        // Métodos assíncronos
        Task<Professor?> ObterPorIdAsync(int id);
        Task<IEnumerable<Professor>> ObterTodosAsync();
        Task CadastrarProfessorAsync(Professor professor);
        Task AtualizarProfessorAsync(Professor professor);
        Task RemoverProfessorAsync(int id);

        // Métodos síncronos
        void Cadastrar(Professor professor);
        IEnumerable<Professor> ObterTodos();
        Professor? ObterPorId(int id);
        void Atualizar(Professor professor);
        void Remover(int id);
    }
}