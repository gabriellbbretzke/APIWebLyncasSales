using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasLyncas.Domain.Commands.AtualizarCliente
{
    public class AtualizarClienteResponse
    {
        public int Id { get; }
        public string Mensagem { get; }

        public AtualizarClienteResponse(int id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }
    }
}
