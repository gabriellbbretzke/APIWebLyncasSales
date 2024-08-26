using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;

namespace VendasLyncas.Domain.Commands.ObterVenda
{
    public class ObterVendaResponse
    {
        public int Id { get; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }

        public DateTime DataFaturamento { get; set; }
        public List<ItemVenda> Itens { get; set; }


        public ObterVendaResponse(int id, int usuarioId, int clienteId, DateTime dataFaturamento, List<ItemVenda> itemVenda)
        {
            Id = id;
            UsuarioId = usuarioId;
            ClienteId = clienteId;
            DataFaturamento = dataFaturamento;
            Itens = itemVenda;
        }
    }
}
