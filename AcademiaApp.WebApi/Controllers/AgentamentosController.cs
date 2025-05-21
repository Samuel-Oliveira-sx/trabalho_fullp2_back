
using System.Threading.Tasks;
using AcademiaApp.Dominio;
using AcademiaApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaApp.API.Controllers
{
    [Route("api/agendamentos")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly IAgendamentoServico _servico;

        public AgendamentosController(IAgendamentoServico servico)
        {
            _servico = servico;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agendamento>> GetAgendamento(int id)
        {
            var agendamento = await _servico.ObterAgendamentoAsync(id);
            return agendamento == null ? NotFound() : Ok(agendamento);
        }

        [HttpPost]
        public async Task<ActionResult> PostAgendamento(Agendamento agendamento)
        {
            await _servico.CadastrarAgendamentoAsync(agendamento);
            return CreatedAtAction(nameof(GetAgendamento), new { id = agendamento.Id }, agendamento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAgendamento(int id, Agendamento agendamento)
        {
            if (id != agendamento.Id)
                return BadRequest("IDs não correspondem.");

            await _servico.AtualizarAgendamentoAsync(agendamento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAgendamento(int id)
        {
            await _servico.RemoverAgendamentoAsync(id);
            return NoContent();
        }
    }
}