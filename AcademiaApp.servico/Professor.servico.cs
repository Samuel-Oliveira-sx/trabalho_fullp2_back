

using AcademiaApp.Dominio;
using AcademiaApp.Dominio.Repositorios;
using AcademiaApp.Servico;
using System.Collections.Generic;

namespace AcademiaApp.Servico.IProfessorServico
{
    public class ProfessorServico : IProfessorServico
    {
        private readonly IProfessorRepositorio _professorRepositorio;

        public ProfessorServico(IProfessorRepositorio professorRepositorio)
        {
            _professorRepositorio = professorRepositorio;
        }

        public void Cadastrar(Professor professor)
        {
            _professorRepositorio.Adicionar(professor);
        }

        public Professor ObterPorId(int id)
        {
            return _professorRepositorio.ObterPorId(id);
        }

        public IEnumerable<Professor> ObterTodos()
        {
            return _professorRepositorio.ObterTodos();
        }

        public void Atualizar(Professor professor)
        {
            _professorRepositorio.Atualizar(professor);
        }

        public void Remover(int id)
        {
            _professorRepositorio.Remover(id);
        }

        public Task<Professor> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Professor>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task CadastrarProfessorAsync(Professor professor)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarProfessorAsync(Professor professor)
        {
            throw new NotImplementedException();
        }

        public Task RemoverProfessorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerificarPlanoAtivoAsync(int id)
        {
            throw new NotImplementedException();
        }

        object IProfessorServico.ObterTodos()
        {
            return ObterTodos();
        }

        object IProfessorServico.ObterPorId(int id)
        {
            return ObterPorId(id);
        }

        Task<Professor> IProfessorServico.ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Professor>> IProfessorServico.ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

       
    }
}