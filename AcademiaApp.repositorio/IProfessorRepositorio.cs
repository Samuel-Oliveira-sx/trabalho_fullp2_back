



namespace AcademiaApp.Dominio.Repositorios
{
    public interface IProfessorRepositorio
    {
        void Adicionar(Professor professor);
        Professor ObterPorId(int id);
        IEnumerable<Professor> ObterTodos();
        void Atualizar(Professor professor);
        void Remover(int id);
        Task AdicionarAsync(Professor professor);
        Task RemoverAsync(int id);
        Task AtualizarAsync(Professor professor);
        Task<IEnumerable<Professor>> ObterTodosAsync();
        Task<Professor?> ObterPorIdAsync(int id);
    }
}