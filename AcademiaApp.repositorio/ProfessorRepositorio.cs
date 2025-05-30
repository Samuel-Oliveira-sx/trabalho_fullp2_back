
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademiaApp.Dominio;
using AcademiaApp.Dominio.Repositorios;

namespace AcademiaApp.Dominio.Repositorios
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private readonly List<Professor> _professores = new List<Professor>();

        // Métodos síncronos
        public void Adicionar(Professor professor)
        {
            professor.Id = _professores.Count + 1;
            _professores.Add(professor);
        }

        public Professor? ObterPorId(int id)
        {
            return _professores.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Professor> ObterTodos()
        {
            return _professores;
        }

        public void Atualizar(Professor professor)
        {
            var existente = ObterPorId(professor.Id);
            if (existente != null)
            {
                existente.Nome = professor.Nome;
                existente.Email = professor.Email;
                existente.Especialidade = professor.Especialidade;
            }
        }

        public void Remover(int id)
        {
            var professor = ObterPorId(id);
            if (professor != null)
            {
                _professores.Remove(professor);
            }
        }

        // Métodos assíncronos
        public async Task AdicionarAsync(Professor professor)
        {
            await Task.Run(() => Adicionar(professor));
        }

        public async Task<Professor?> ObterPorIdAsync(int id)
        {
            return await Task.Run(() => ObterPorId(id));
        }

        public async Task<IEnumerable<Professor>> ObterTodosAsync()
        {
            return await Task.Run(() => ObterTodos());
        }

        public async Task AtualizarAsync(Professor professor)
        {
            await Task.Run(() => Atualizar(professor));
        }

        public async Task RemoverAsync(int id)
        {
            await Task.Run(() => Remover(id));
        }
    }
}