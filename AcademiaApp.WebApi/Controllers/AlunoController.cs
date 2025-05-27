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
        /// Obtém todos os alunos cadastrados.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            Console.WriteLine($"✅ Banco conectado: {_context.Database.ProviderName}");
            Console.WriteLine($"🛠️ String de conexão: {_context.Database.GetConnectionString()}");

            var tabelaExiste = await _context.Database.ExecuteSqlRawAsync("SELECT name FROM sqlite_master WHERE type='table' AND name='Alunos';");
            if (tabelaExiste == 0)
            {
                Console.WriteLine("❌ A tabela `Alunos` não existe no banco! Verifique as migrations.");
                return NotFound(new { Message = "Erro: A tabela `Alunos` não foi encontrada no banco de dados!" });
            }

            var alunos = await _context.Alunos
                .Select(a => new
                {
                    a.Id,
                    a.Nome,
                    a.Email,
                    a.CPF,
                    a.Senha,
                    a.DataNascimento,
                    a.DataMatricula,
                    a.Ativo
                })
                .ToListAsync();

            Console.WriteLine($"🔥 Total de alunos encontrados no banco: {alunos.Count}");

            if (!alunos.Any())
            {
                Console.WriteLine("❌ Nenhum aluno encontrado! Certifique-se de que os registros existem no banco.");
                return NotFound(new { Message = "Nenhum aluno encontrado no banco de dados!" });
            }

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