
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademiaApp.Dominio;

namespace AcademiaApp.Repository
{
    public interface IAgendamentoRepositorio
    {
        Task<Agendamento> ObterPorIdAsync(int id);
        Task<IEnumerable<Agendamento>> ObterTodosAsync();
        Task AdicionarAsync(Agendamento agendamento);
        Task AtualizarAsync(Agendamento agendamento);
        Task RemoverAsync(int id);
    }
}