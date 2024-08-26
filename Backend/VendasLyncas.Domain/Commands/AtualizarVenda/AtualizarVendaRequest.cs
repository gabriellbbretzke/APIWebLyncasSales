using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VendasLyncas.Domain.DTOs;

namespace VendasLyncas.Domain.Commands.AtualizarVenda
{
    public class AtualizarVendaRequest : IRequest<CommandResponse>
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataFaturamento { get; set; }
        public List<ItemVendaAdicionarDTO> Itens { get; set; }
    }
}
