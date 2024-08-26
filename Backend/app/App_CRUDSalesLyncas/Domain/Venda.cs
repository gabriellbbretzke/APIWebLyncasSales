using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CRUDSalesLyncas.Domain
{
    public class Venda
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataFaturamento { get; set; }
        public IList<ItemVenda> ItemVenda { get; set; }
        public double ValorTotal { get; set; }
    }

    //public void AdicionarVenda()
    //{

    //}

    //public void ListarVendas()
    //{

    //}
}
