using MediatR;
using VendasLyncas.Domain.DTOs;

namespace VendasLyncas.Domain.Commands.RemoverUsuario
{
    public class RemoverUsuarioRequest : IRequest<CommandResponse>
    {
        public int Id { get; set; }
    }
}
