
using System;
using System.Threading.Tasks;
using AcademiaApp.Dominio;
using AcademiaApp.Repository;

namespace AcademiaApp.Services
{
    public interface IAgendamentoServico
    {
        Task<Agendamento> ObterAgendamentoAsync(int id);
        Task CadastrarAgendamentoAsync(Agendamento agendamento);
        Task AtualizarAgendamentoAsync(Agendamento agendamento);
        Task RemoverAgendamentoAsync(int id);
        Task<bool> VerificarConflitoHorarioAsync(int treinadorId, DateTime dataHora);
    }

    public class AgendamentoServico : IAgendamentoServico
    {
        private readonly IAgendamentoRepositorio _repositorio;

        public AgendamentoServico(IAgendamentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Agendamento> ObterAgendamentoAsync(int id)
        {
            return await _repositorio.ObterPorIdAsync(id);
        }

        public async Task CadastrarAgendamentoAsync(Agendamento agendamento)
        {
            var conflito = await VerificarConflitoHorarioAsync(agendamento.TreinadorId, agendamento.DataHora);
            if (conflito)
                throw new Exception("Horário já está ocupado!");

            await _repositorio.AdicionarAsync(agendamento);
        }

        public async Task AtualizarAgendamentoAsync(Agendamento agendamento)
        {
            await _repositorio.AtualizarAsync(agendamento);
        }

        public async Task RemoverAgendamentoAsync(int id)
        {
            await _repositorio.RemoverAsync(id);
        }

        public async Task<bool> VerificarConflitoHorarioAsync(int treinadorId, DateTime dataHora)
        {
            var agendamentos = await _repositorio.ObterTodosAsync();
            return agendamentos.Any(a => a.TreinadorId == treinadorId && a.DataHora == dataHora);
        }
    }
}