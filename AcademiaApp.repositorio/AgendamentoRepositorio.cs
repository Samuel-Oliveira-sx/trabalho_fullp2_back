
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademiaApp.Dominio;
using AcademiaApp.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace AcademiaApp.Repository
{
    public class AgendamentoRepositorio : IAgendamentoRepositorio
    {
        private readonly AcademiaDbContext _context;

        public AgendamentoRepositorio(AcademiaDbContext context)
        {
            _context = context;
        }

        public async Task<Agendamento> ObterPorIdAsync(int id)
        {
            return await _context.Agendamentos.FindAsync(id);
        }

        public async Task<IEnumerable<Agendamento>> ObterTodosAsync()
        {
            return await _context.Agendamentos.ToListAsync();
        }

        public async Task AdicionarAsync(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Agendamento agendamento)
        {
            _context.Agendamentos.Update(agendamento);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}