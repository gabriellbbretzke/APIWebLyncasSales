using MediatR;
using VendasLyncas.Domain.DTOs;

namespace VendasLyncas.Domain.Commands.ObterVenda
{
    public class ObterVendaRequest : IRequest<CommandResponse>
    {
        public int Id { get; set; }
    }
}
