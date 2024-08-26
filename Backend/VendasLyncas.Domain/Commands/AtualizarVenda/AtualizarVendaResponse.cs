using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasLyncas.Domain.Commands.AtualizarVenda
{
    public class AtualizarVendaResponse
    {
        public int Id { get; }
        public string Mensagem { get; }

        public AtualizarVendaResponse(int id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }
    }
}
