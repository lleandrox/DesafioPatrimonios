using System.Net;
using Microsoft.AspNetCore.Mvc;
using patrimonios.domain.Dtos;
using patrimonios.domain.Entities;
using Patrimonios.api.Inputs;
using Patrimonios.Negocio;

namespace Patrimonios.api.Controllers
{
    [Produces("application/json")]
    [Route("api/Marca")]
    public class MarcaController : ControllerBase
    {
        private  readonly MarcaNegocio _marcaNegocio;

        public MarcaController()
        {
            _marcaNegocio = new MarcaNegocio();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Marca), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            return Ok(_marcaNegocio.Selecionar());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Marca), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetId([FromRoute] int id)
        {
            return Ok(_marcaNegocio.SelecionarPorId(id));
        }

        [HttpGet]
        [Route("{id}/Patrimonio")]
        [ProducesResponseType(typeof(MarcaDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetByIdMarcaPatrimonio([FromRoute] int id)
        {
            return Ok(_marcaNegocio.SelecionarPatrimonioPorMarcaId(id));
        }
        [HttpPost]
        [ProducesResponseType(typeof(Marca), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody]MarcaInput input)
        {
            return Ok(_marcaNegocio.Inserir(input));
        }
        
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Marca), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put([FromRoute]int id, [FromBody]Marca input)
        {
            return Ok(_marcaNegocio.Alterar(id,input));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Marca), 200)]
        [ProducesResponseType(400)]
        public IActionResult Delete([FromRoute]int id)
        {
            _marcaNegocio.Deletar(id);
            return Ok();
        }
    }
}
