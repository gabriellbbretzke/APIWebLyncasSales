using Microsoft.AspNetCore.Mvc;

namespace VendasLyncas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Cliente> CriarNovosClientes([FromBody] Cliente novoCliente)
        {
            //validate and save to database
            var clienteCriado = Cliente.AdicionarCliente(novoCliente);
            if (clienteCriado)
                return BadRequest();

            return Created("", novoCliente);
        }

        [HttpGet]
        public ActionResult GetClientes()
        {
            var consultaUsuarioDb = Cliente.ListarClientes();
            return Ok(consultaUsuarioDb);
        }

        [HttpGet("{id}")]
        public ActionResult GetClientes(int id)
        {
            var consultaUsuarioDb = Cliente.ListarQuantidadeClientes(id);
            return Ok(consultaUsuarioDb);
        }

        [HttpDelete("{id}")]  //api/recipes/1323
        public ActionResult DeleteClientes(int id)
        {
            if (Cliente.RemoverCliente(id))
            {
                return Ok($"Removido Cliente ID: {id}");
            }
            else {
                return NoContent();
            }
        }
    }
}
