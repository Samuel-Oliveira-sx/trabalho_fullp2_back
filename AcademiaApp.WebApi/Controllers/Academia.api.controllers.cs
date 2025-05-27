
using System.Threading.Tasks;
using AcademiaApp.Dominio;
using AcademiaApp.Servico;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaApp.API.Controllers
{
    [Route("api/aluno")]
    [ApiController]
    public class AcademiaApiController : ControllerBase
    {
        private readonly IAlunoServico _servico;

        public AcademiaApiController(IAlunoServico servico)
        {
            _servico = servico;
        }

        // Método GET com ID removido
    }
}