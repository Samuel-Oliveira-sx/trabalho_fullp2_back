
using System.Threading.Tasks;
using AcademiaApp.Dominio;

namespace AcademiaApp.Servico
{
    public interface IAlunoServico
    {
        Task<Aluno> ObterAlunoAsync(int id);
        Task CadastrarAlunoAsync(Aluno aluno);
        Task AtualizarAlunoAsync(Aluno aluno);
        Task RemoverAlunoAsync(int id);
        bool VerificarPlanoAtivo(int id);
    }
}