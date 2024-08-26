using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;

namespace VendasLyncas.Domain.Commands.ListarVenda
{
    public class ListarVendaResponse
    {
        public IEnumerable<ListarVendaDTO> listadeVendas { get; protected set; }

        public ListarVendaResponse(IEnumerable<ListarVendaDTO> vendas)
        {
            listadeVendas = vendas;
        }
    }
}
