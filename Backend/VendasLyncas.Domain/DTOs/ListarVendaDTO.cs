using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VendasLyncas.Domain.Entities;

namespace VendasLyncas.Domain.DTOs
{
    public class ListarVendaDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get;  set; }
        public string? ClienteNome { get; set; }
        public int QuantidadeItens { get;  set; }
        public DateTime DataVenda { get;  set; }
        public DateTime DataFaturamento { get;  set; }
        public decimal ValorTotal { get;  set; }
        public virtual IEnumerable<ItemVenda> Itens { get; set; }
    }
}
