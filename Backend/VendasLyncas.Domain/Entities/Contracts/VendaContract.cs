using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasLyncas.Domain.Entities.Contracts
{
    public static class VendaContract
    {
        public static void AdicionarVendaContract(this Venda venda)
        {
            new AddNotifications<Venda>(venda)
                .IfLowerOrEqualsThan(p => p.QuantidadeItens, 0)
                .IfNull(p => p.DataVenda)
                .IfNull(p => p.DataFaturamento)
                .IfLowerOrEqualsThan(p => p.ValorTotal, 0);
        }

        public static void AtualizarVendaContract(this Venda venda)
        {
            new AddNotifications<Venda>(venda)
                .IfLowerOrEqualsThan(p => p.QuantidadeItens, 0)
                .IfNull(p => p.DataVenda)
                .IfNull(p => p.DataFaturamento)
                .IfLowerOrEqualsThan(p => p.ValorTotal, 0);
        }
    }
}
