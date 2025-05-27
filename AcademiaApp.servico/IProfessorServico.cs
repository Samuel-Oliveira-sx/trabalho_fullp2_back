
using System.Collections.Generic;
using System.Threading.Tasks;

using AcademiaApp.Dominio;

namespace AcademiaApp.Servico.IProfessorServico
{
    public interface IProfessorServico
    {
        Task<Professor> ObterPorIdAsync(int id); 
        Task<IEnumerable<Professor>> ObterTodosAsync(); 
        Task CadastrarProfessorAsync(Professor professor); 
        Task AtualizarProfessorAsync(Professor professor); 
        Task RemoverProfessorAsync(int id); 
        Task<bool> VerificarPlanoAtivoAsync(int id);
        void Cadastrar(Professor professor);
        object ObterTodos();
        object ObterPorId(int id);
        void Atualizar(Professor professor);
        void Remover(int id);
    }
}