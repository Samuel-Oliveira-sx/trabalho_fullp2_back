
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademiaApp.Dominio;
using AcademiaApp.Servico;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaApp.API.Controllers
{
    [Route("api/alunos")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoServico _servico;

        public AlunosController(IAlunoServico servico)
        {
            _servico = servico;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _servico.ObterAlunoAsync(id);
            return aluno == null ? NotFound() : Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult> PostAluno(Aluno aluno)
        {
            await _servico.CadastrarAlunoAsync(aluno);
            return CreatedAtAction(nameof(GetAluno), new { id = aluno.Id }, aluno);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.Id)
                return BadRequest("IDs não correspondem.");

            await _servico.AtualizarAlunoAsync(aluno);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAluno(int id)
        {
            await _servico.RemoverAlunoAsync(id);
            return NoContent();
        }
    }
}