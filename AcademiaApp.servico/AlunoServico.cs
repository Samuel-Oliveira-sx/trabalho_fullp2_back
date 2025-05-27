
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademiaApp.Dominio;
using AcademiaApp.Repositorio;

namespace AcademiaApp.Servico
{
    public interface IAlunoServico
    {
        Task<Aluno?> ObterPorIdAsync(int? id); // ID agora é opcional
        Task<IEnumerable<Aluno>> ObterTodosAsync();
        Task CadastrarAlunoAsync(Aluno aluno);
        Task AtualizarAlunoAsync(Aluno aluno);
        Task RemoverAlunoAsync(int id);
        Task<Aluno?> ObterAlunoPorNomeAsync(string nome);
        Task<IEnumerable<Aluno>> ObterOuTodosAsync(int? id = null); // Novo método flexível
    }

    public class AlunoServico : IAlunoServico
    {
        private readonly AlunoRepositorio _repositorio;

        public AlunoServico(AlunoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Aluno?> ObterPorIdAsync(int? id)
        {
            if (!id.HasValue)
                return null; // Retorna null se o ID não for fornecido

            return await _repositorio.ObterPorIdAsync(id.Value);
        }

        public async Task<IEnumerable<Aluno>> ObterTodosAsync()
        {
            return await _repositorio.ObterTodosAsync();
        }

        public async Task<IEnumerable<Aluno>> ObterOuTodosAsync(int? id = null)
        {
            return id.HasValue
                ? new List<Aluno> { await ObterPorIdAsync(id.Value) ?? new Aluno() }
                : await ObterTodosAsync();
        }

        public async Task CadastrarAlunoAsync(Aluno aluno)
        {
            if (string.IsNullOrEmpty(aluno.Nome))
                throw new ArgumentException("O nome do aluno é obrigatório.");

            await _repositorio.AdicionarAsync(aluno);
        }

        public async Task AtualizarAlunoAsync(Aluno aluno)
        {
            await _repositorio.AtualizarAsync(aluno);
        }

        public async Task RemoverAlunoAsync(int id)
        {
            await _repositorio.RemoverAsync(id);
        }

        public async Task<Aluno?> ObterAlunoPorNomeAsync(string nome)
        {
            return await _repositorio.ObterPorNomeAsync(nome);
        }
    }
}