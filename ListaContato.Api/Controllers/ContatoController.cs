using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ListaContatos.Domain.Model;
using System.Linq;
using ListaContatos.Api.Services;

namespace ListaContatos.Api.Controllers
{
    [ApiController]
    [Route("v1/Contatos")]
    public class ContatoController : ControllerBase
    {
        private readonly ServiceContato _service;

        public ContatoController(ServiceContato service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("TodosContatos")]
        public async Task<ActionResult<List<Contato>>> Get()
        {
            var contatos = _service.Listar();
            if (contatos.Any())
            {
                return Ok(contatos);
            }
            return NoContent();
        }
    }
}