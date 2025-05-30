

using AcademiaApp.Dominio;
using AcademiaApp.Dominio.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaApp.Servico
{
    public class ProfessorServico : IProfessorServico
    {
        private readonly IProfessorRepositorio _professorRepositorio;

        public ProfessorServico(IProfessorRepositorio professorRepositorio)
        {
            _professorRepositorio = professorRepositorio;
        }

        // Métodos assíncronos
        public async Task<Professor?> ObterPorIdAsync(int id)
        {
            return await _professorRepositorio.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Professor>> ObterTodosAsync()
        {
            return await _professorRepositorio.ObterTodosAsync() ?? new List<Professor>();
        }

        public async Task CadastrarProfessorAsync(Professor professor)
        {
            if (professor == null)
                throw new ArgumentNullException(nameof(professor));

            await _professorRepositorio.AdicionarAsync(professor);
        }

        public async Task AtualizarProfessorAsync(Professor professor)
        {
            if (professor == null)
                throw new ArgumentNullException(nameof(professor));

            await _professorRepositorio.AtualizarAsync(professor);
        }

        public async Task RemoverProfessorAsync(int id)
        {
            await _professorRepositorio.RemoverAsync(id);
        }

        // Métodos síncronos
        public void Cadastrar(Professor professor)
        {
            if (professor == null)
                throw new ArgumentNullException(nameof(professor));

            _professorRepositorio.Adicionar(professor);
        }

        public IEnumerable<Professor> ObterTodos()
        {
            return _professorRepositorio.ObterTodos() ?? new List<Professor>();
        }

        public Professor? ObterPorId(int id)
        {
            return _professorRepositorio.ObterPorId(id);
        }

        public void Atualizar(Professor professor)
        {
            if (professor == null)
                throw new ArgumentNullException(nameof(professor));

            _professorRepositorio.Atualizar(professor);
        }

        public void Remover(int id)
        {
            _professorRepositorio.Remover(id);
        }
    }
}