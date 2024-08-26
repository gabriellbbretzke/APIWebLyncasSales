using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasLyncas.Domain.Commands.AdicionarCliente
{
    public class AdicionarClienteResponse
    {
        public int Id { get; }
        public string Mensagem { get; }

        public AdicionarClienteResponse(int id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }
    }
}
