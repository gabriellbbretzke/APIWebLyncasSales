using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VendasLyncas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {


        [HttpPost]
        public ActionResult<Venda> AdicionarVenda([FromBody] Venda novaVenda)
        {
            var vendaCriada = Venda.AdicionarVenda(novaVenda);
            return Created("", novaVenda);
        }

        [HttpGet]
        public ActionResult ConsultarVenda()
        {
            var consultaVenda = Venda.ListarVendas();
            return Ok(consultaVenda);
        }

        [HttpGet("{quantidadeVendas}")]
        public ActionResult ConsultaVenda(int quantidadeVendas)
        {
            var consultaVenda = Venda.ListarQuantidadeVendas(quantidadeVendas);
            return Ok(consultaVenda);
        }

        [HttpPut]
        public ActionResult<Venda> AtualizarVenda(Venda vendaAAlterar)
        {
            var vendaAlterada = Venda.AlterarVenda(vendaAAlterar);
            return Ok(vendaAlterada);
        }

        [HttpDelete("{id}")]
        public ActionResult RemoverVenda (int id)
        {
            var vendaARemover = Venda.RemoverVenda(id);
            if (vendaARemover)
                return Ok("Venda removida");
            return BadRequest();
        }
    }
}