using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasLyncas.Domain.Commands.RemoverVenda
{
    public class RemoverVendaResponse
    {
        public int Id { get; }
        public string Mensagem { get; }

        public RemoverVendaResponse(int id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }
    }
}
