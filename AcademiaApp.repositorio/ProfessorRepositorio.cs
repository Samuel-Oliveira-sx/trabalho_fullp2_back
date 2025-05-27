
using System.Collections.Generic;
using System.Linq;
using AcademiaApp.Dominio.Repositorios;


namespace AcademiaApp.Dominio.Repositorios
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private readonly List<Professor> _professores = new List<Professor>(); 

        public void Adicionar(Professor professor)
        {
            professor.Id = _professores.Count + 1;
            _professores.Add(professor);
        }

        public Professor ObterPorId(int id)
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
    }
}