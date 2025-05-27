


namespace AcademiaApp.Dominio.Repositorios
{
    public interface IProfessorRepositorio
    {
        void Adicionar(Professor professor);
        Professor ObterPorId(int id);
        IEnumerable<Professor> ObterTodos();
        void Atualizar(Professor professor);
        void Remover(int id);
    }
}