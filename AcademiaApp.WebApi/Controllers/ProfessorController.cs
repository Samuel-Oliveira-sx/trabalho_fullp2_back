

using AcademiaApp.Dominio;
using AcademiaApp.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AcademiaApp.API.Controllers
{
    [Route("api/professor")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly AcademiaDbContext _context;

        public ProfessorController(AcademiaDbContext context)
        {
            _context = context;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastrar([FromBody] Professor professor)
        {
            _context.Professores.Add(professor);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Cadastro realizado com sucesso!", Professor = professor });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Professor professor)
        {
            var professorExistente = await _context.Professores
                .FirstOrDefaultAsync(p => p.Email == professor.Email && p.Senha == professor.Senha);

            if (professorExistente == null)
                return Unauthorized(new { Message = "Credenciais inválidas!" });

            return Ok(new { Message = "Login realizado com sucesso!", Professor = professorExistente });
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> ObterProfessor(int? id)
        {
            if (id.HasValue)
            {
                var professor = await _context.Professores.FindAsync(id);
                if (professor == null)
                    return NotFound(new { Message = "Professor não encontrado!" });

                return Ok(professor);
            }

            var professores = await _context.Professores.ToListAsync();
            if (!professores.Any())
                return NoContent();

            return Ok(professores);
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Atualizar(int? id, [FromBody] Professor professor)
        {
            if (!id.HasValue)
                return BadRequest(new { Message = "ID não informado! Para atualizar, forneça um ID." });

            var professorExistente = await _context.Professores.FindAsync(id);

            if (professorExistente == null)
                return NotFound(new { Message = "Professor não encontrado!" });

            professorExistente.Nome = professor.Nome;
            professorExistente.Email = professor.Email;
            professorExistente.Senha = professor.Senha;

            await _context.SaveChangesAsync();

            return Ok(new { Message = "Dados do professor atualizados!", Professor = professorExistente });
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Remover(int? id)
        {
            if (!id.HasValue)
                return BadRequest(new { Message = "ID não informado! Para remover, forneça um ID." });

            var professorExistente = await _context.Professores.FindAsync(id);

            if (professorExistente == null)
                return NotFound(new { Message = "Professor não encontrado!" });

            _context.Professores.Remove(professorExistente);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Professor removido com sucesso!" });
        }
    }
}