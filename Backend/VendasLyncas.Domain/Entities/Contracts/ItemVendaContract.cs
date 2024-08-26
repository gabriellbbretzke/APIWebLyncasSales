using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasLyncas.Domain.Entities.Contracts
{
    public static class ItemVendaContract
    {
        public static void AdicionarItemVendaContract(this ItemVenda itemVenda)
        {
            new AddNotifications<ItemVenda>(itemVenda)
                .IfNullOrInvalidLength(p => p.Descricao, 1, 200)
                .IfLowerOrEqualsThan(p => p.Quantidade, 0)
                .IfLowerOrEqualsThan(p => p.Valor, 0)
                .IfLowerOrEqualsThan(p => p.TotalItensVenda, 0);
        }

        public static void AtualizarItemVendaContract(this ItemVenda itemVenda)
        {
            new AddNotifications<ItemVenda>(itemVenda)
                .IfNullOrInvalidLength(p => p.Descricao, 1, 200)
                .IfLowerOrEqualsThan(p => p.Quantidade, 0)
                .IfLowerOrEqualsThan(p => p.Valor, 0)
                .IfLowerOrEqualsThan(p => p.TotalItensVenda, 0);
        }
    }
}
