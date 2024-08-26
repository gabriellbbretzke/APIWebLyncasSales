using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendasLyncas.Domain.Commands.AdicionarUsuario;
using VendasLyncas.Domain.Commands.AtualizarUsuario;
using VendasLyncas.Domain.Commands.ListarUsuario;
using VendasLyncas.Domain.Commands.ObterUsuario;
using VendasLyncas.Domain.Commands.RemoverUsuario;
using VendasLyncas.Domain.DTOs;

namespace VendasLyncas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        [HttpGet]
        public Task<CommandResponse> ListaUsuarios([FromServices] IMediator _mediator)
        {
            return _mediator.Send(new ListarUsuarioRequest());
        }

        [HttpGet("{id}")]
        public Task<CommandResponse> ObtemUsuario([FromServices] IMediator _mediator, int id)
        {
            var obterUsuario = new ObterUsuarioRequest { Id = id };
            return _mediator.Send(obterUsuario);
        }

        [HttpPost]
        public async Task<CommandResponse> AdicionaUsuario([FromServices] IMediator _mediator, [FromBody] AdicionarUsuarioRequest cadastrarUsuario)
        {
            var response = await _mediator.Send(cadastrarUsuario);
            return response;
        }

        [HttpPut]
        public async Task<CommandResponse> AtualizaUsuario([FromServices] IMediator _mediator, [FromBody] AtualizarUsuarioRequest atualizarUsuario)
        {
            var response = await _mediator.Send(atualizarUsuario);
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<CommandResponse> RemoveUsuario([FromServices] IMediator _mediator, int id)
        {
            var removerUsuario = new RemoverUsuarioRequest { Id = id };
            return await _mediator.Send(removerUsuario);
        }
    }
}
