using System.Text.Json.Serialization;
using VendasLyncas.Domain.Entities.Contracts;

namespace VendasLyncas.Domain.Entities
{
    public class Venda : EntidadeBase
    {
        private List<ItemVenda> _itens = new();

        public int UsuarioId { get; private set; }
        public int ClienteId { get; private set; }
        public int QuantidadeItens { get; private set; }
        public DateTime DataVenda { get; private set; } = DateTime.Now;
        public DateTime DataFaturamento { get; private set; }
        public decimal ValorTotal { get; private set; }
        public virtual IEnumerable<ItemVenda> Itens => _itens;

        //Propriedade de Navegabilidade
        [JsonIgnore]
        public virtual Cliente Cliente { get; private set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; private set; }

        //Contrutor para EF
        protected Venda() { }

        public Venda(int usuarioId, int clienteId, int quantidadeItens, DateTime dataFaturamento, decimal valorTotal)
        {
            UsuarioId = usuarioId;
            ClienteId = clienteId;
            QuantidadeItens = quantidadeItens;
            DataFaturamento = dataFaturamento;
            ValorTotal = valorTotal;

            this.AdicionarVendaContract();
        }

        public void AtualizarVenda(int usuarioId, int clienteId, int quantidadeItens, DateTime dataFaturamento, decimal valorTotal)
        {
            UsuarioId = usuarioId;
            ClienteId = clienteId;
            QuantidadeItens = quantidadeItens;
            DataFaturamento = dataFaturamento;
            ValorTotal = valorTotal;

            this.AtualizarVendaContract();
        }

        public void AdicionarItem(ItemVenda itemVenda)
        {
            AddNotifications(itemVenda);
            _itens.Add(itemVenda);
        }

        public void AtualizarItem(ItemVenda itemVenda)
        {
            var vi = _itens.FirstOrDefault(p => p.Id == itemVenda.Id);
            vi?.Atualizar(itemVenda.Descricao, itemVenda.Valor, itemVenda.Quantidade, itemVenda.Valor);

            AddNotifications(vi);
        }

        public void RemoverItem(ItemVenda itemVenda)
        {
            _itens.Remove(itemVenda);
        }
    }
}
