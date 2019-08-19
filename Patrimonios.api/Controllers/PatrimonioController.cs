using Microsoft.AspNetCore.Mvc;
using patrimonios.domain.Dtos;
using patrimonios.domain.Entities;
using Patrimonios.api.Inputs;
using Patrimonios.dado;
using Patrimonios.Negocio;

namespace Patrimonios.api.Controllers
{
    [Produces("application/json")]
    [Route("api/Patrimonio")]
    public class PatrimonioController : ControllerBase
    {
        private readonly PatrimonioNegocio _patrimonioNegocio;

        public PatrimonioController()
        {
            _patrimonioNegocio = new PatrimonioNegocio();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Patrimonio), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            return Ok(_patrimonioNegocio.Selecionar());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Patrimonio), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetId([FromRoute] int id)
        {
            return Ok(_patrimonioNegocio.SelecionarPorId(id));
        }
        [HttpPost]
        [ProducesResponseType(typeof(PatrimonioInput), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody]PatrimonioInput input)
        {
            return Ok(_patrimonioNegocio.Inserir(input));
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(PatrimonioInput), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put([FromRoute]int id, [FromBody]Patrimonio input)
        {
            return Ok(_patrimonioNegocio.Alterar(id, input));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Patrimonio), 200)]
        [ProducesResponseType(400)]
        public IActionResult Delete([FromRoute]int id)
        {
            _patrimonioNegocio.Deletar(id);
            return Ok();
        }
    }
}
