
using System;
using System.Threading.Tasks;
using AcademiaApp.Dominio;
using AcademiaApp.Repositorio;

namespace AcademiaApp.servico
{
    public interface IAlunoServico
    {
        Task<Aluno> ObterAlunoAsync(int id);
        Task CadastrarAlunoAsync(Aluno aluno);
        Task AtualizarAlunoAsync(Aluno aluno);
        Task RemoverAlunoAsync(int id);
        bool VerificarPlanoAtivo(int id);
    }

    public class AlunoService : IAlunoServico
    {
        private readonly IAlunoRepositorio _repositorio;

        public AlunoService(IAlunoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Aluno> ObterAlunoAsync(int id)
        {
            return await _repositorio.ObterPorIdAsync(id);
        }

        public async Task CadastrarAlunoAsync(Aluno aluno)
        {
            if (string.IsNullOrEmpty(aluno.Nome))
                throw new Exception("O nome do aluno é obrigatório.");

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

        public bool VerificarPlanoAtivo(int id)
        {
            var aluno = _repositorio.ObterPorIdAsync(id).Result;
            return aluno?.TemPlanoAtivo() ?? false;
        }
    }
}
