using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasLyncas.Domain.Entities.Contracts;

namespace VendasLyncas.Domain.Entities
{
    public class ItemVenda : EntidadeBase
    {

        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public int Quantidade { get; private set; }        
        public decimal TotalItensVenda { get; private set; }
        public int VendaId { get; private set; }

        //Contrutor para EF
        protected ItemVenda() { }

        public ItemVenda(string descricaoItem, decimal valorItem, int quantidadeItem, decimal valorTotalItem)
        {
            Descricao = descricaoItem;
            Valor = valorItem;
            Quantidade = quantidadeItem;
            TotalItensVenda = valorTotalItem;

            this.AdicionarItemVendaContract();
        }

        public void Atualizar(string descricaoItem, decimal valorItem, int quantidadeItem, decimal valorTotalItem)
        {
            Descricao = descricaoItem;
            Valor = valorItem;
            Quantidade = quantidadeItem;
            TotalItensVenda = valorTotalItem;

            this.AtualizarItemVendaContract();
        }
    }
}
