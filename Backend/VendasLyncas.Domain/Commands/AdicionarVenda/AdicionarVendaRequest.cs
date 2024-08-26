using MediatR;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;

namespace VendasLyncas.Domain.Commands.AdicionarVenda
{
    public class AdicionarVendaRequest : IRequest<CommandResponse>
    {
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }

        public DateTime DataFaturamento { get; set; }
        public List<ItemVendaAdicionarDTO> Itens { get; set; }
        
    }
}
