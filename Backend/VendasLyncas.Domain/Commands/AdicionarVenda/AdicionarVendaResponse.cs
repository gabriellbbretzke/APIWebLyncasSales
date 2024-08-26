using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasLyncas.Domain.Commands.AdicionarVenda
{
    public class AdicionarVendaResponse
    {
        public int Id { get; }
        public string Mensagem { get; }

        public AdicionarVendaResponse(int id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }
    }
}
