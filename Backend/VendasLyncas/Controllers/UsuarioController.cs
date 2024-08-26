using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VendasLyncas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetUsuarios()
        {
            var consultaUsuarioDb = Usuario.ListarUsuarios();
            return Ok(consultaUsuarioDb);
        }

        [HttpGet("{quantidadeUsuarios}")]
        public ActionResult GetUsuarios(int quantidadeUsuarios)
        {
            var validaUsuarioDb = Usuario.ListarQuantidadeUsuario(quantidadeUsuarios);

            return Ok(validaUsuarioDb);
        }

        //[HttpGet("{id}")]
        //public ActionResult ValidaUsuarios(int id)
        //{
        //    var consultaUsuarioDb = Usuario.ValidarLoginUsuario(id);
        //    if (consultaUsuarioDb)
        //        return Ok(consultaUsuarioDb);
        //    return BadRequest("Usuário não existe ou senha incorreta!");
        //}

        [HttpDelete("{id}")]  //api/recipes/1323
        public ActionResult DeleteUsuarios(int id)
        {
            if (Usuario.RemoverUsuario(id))
            {
                return Ok($"Removido Usuario ID: {id}");
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public ActionResult<Usuario> CriarNovosUsuarios([FromBody] Usuario novoUsuario)
        {
            //validate and save to database
            var usuarioCriado = Usuario.AdicionarUsuario(novoUsuario);
            if (usuarioCriado)
                return BadRequest();

            return Created("", novoUsuario);
        }
    }
}
