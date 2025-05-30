using AcademiaApp.Dominio;
using AcademiaApp.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AcademiaApp.API.Controllers
{
    [Route("api/aluno")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AcademiaDbContext _context;

        public AlunoController(AcademiaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Autentica um aluno no sistema.
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Aluno aluno)
        {
            if (aluno == null)
                return BadRequest(new { Message = "Dados inválidos!" });

            var alunoExistente = await _context.Alunos
                .FirstOrDefaultAsync(a => a.Email == aluno.Email && a.Senha == aluno.Senha);

            if (alunoExistente == null)
                return Unauthorized(new { Message = "Credenciais inválidas!" });

            return Ok(new { Message = "Login realizado com sucesso!", Aluno = alunoExistente });
        }

        /// <summary>
        /// Obtém todos os alunos cadastrados.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var alunos = await _context.Alunos
                .Select(a => new
                {
                    a.Id,
                    a.Nome,
                    a.Email,
                    a.CPF,
                    a.Senha,
                    a.DataNascimento
                })
                .ToListAsync();

            if (!alunos.Any())
                return NotFound(new { Message = "Nenhum aluno encontrado no banco de dados!" });

            return Ok(alunos);
        }

        /// <summary>
        /// Cadastra um novo aluno no sistema.
        /// </summary>
        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastrar([FromBody] Aluno aluno)
        {
            if (aluno == null)
                return BadRequest(new { Message = "Dados inválidos!" });

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Cadastro realizado com sucesso!", Aluno = aluno });
        }

        /// <summary>
        /// Atualiza os dados de um aluno.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Aluno aluno)
        {
            var alunoExistente = await _context.Alunos.FindAsync(id);

            if (alunoExistente == null)
                return NotFound(new { Message = "Aluno não encontrado!" });

            alunoExistente.Nome = aluno.Nome;
            alunoExistente.Email = aluno.Email;
            alunoExistente.Senha = aluno.Senha;

            await _context.SaveChangesAsync();
            return Ok(new { Message = "Dados do aluno atualizados!", Aluno = alunoExistente });
        }

        /// <summary>
        /// Remove um aluno do sistema.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var alunoExistente = await _context.Alunos.FindAsync(id);

            if (alunoExistente == null)
                return NotFound(new { Message = "Aluno não encontrado!" });

            _context.Alunos.Remove(alunoExistente);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Aluno removido com sucesso!" });
        }
    }
}