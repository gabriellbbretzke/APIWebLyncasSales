using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CRUDSalesLyncas.Domain
{
    public class ItemVenda
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public Venda Venda { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public double TotalItensVenda { get; set; }
    }

    //public void AdicionarItem()
    //{

    //}
}
