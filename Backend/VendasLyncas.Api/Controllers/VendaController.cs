using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendasLyncas.Domain.Commands.AdicionarCliente;
using VendasLyncas.Domain.Commands.AdicionarVenda;
using VendasLyncas.Domain.Commands.AtualizarVenda;
using VendasLyncas.Domain.Commands.ListarVenda;
using VendasLyncas.Domain.Commands.ObterVenda;
using VendasLyncas.Domain.Commands.RemoverCliente;
using VendasLyncas.Domain.Commands.RemoverVenda;
using VendasLyncas.Domain.DTOs;

namespace VendasLyncas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        [HttpPost]
        public async Task<CommandResponse> AdicionaVenda([FromServices] IMediator _mediator, [FromBody] AdicionarVendaRequest novaVenda)
        {
            var response = await _mediator.Send(novaVenda);
            return response;
        }

        [HttpGet]
        public Task<CommandResponse> ListaVenda([FromServices] IMediator _mediator)
        {
            return _mediator.Send(new ListarVendaRequest());
        }

        [HttpGet("{id}")]
        public Task<CommandResponse> ObtemVenda([FromServices] IMediator _mediator, int id)
        {
            var obterVenda = new ObterVendaRequest { Id = id };
            return _mediator.Send(obterVenda);
        }

        [HttpPut]
        public async Task<CommandResponse> AtualizaVenda([FromServices] IMediator _mediator, [FromBody]AtualizarVendaRequest atualizarVenda)
        {
            var response = await _mediator.Send(atualizarVenda);
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<CommandResponse> RemoverVenda([FromServices] IMediator _mediator, int id)
        {
            var removeVenda = new RemoverVendaRequest { Id=id };
            return await _mediator.Send(removeVenda);
        }
    }
}