using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasLyncas.Domain.Commands.RemoverCliente
{
    public class RemoverClienteResponse
    {
        public int Id { get; }
        public string Mensagem { get; }

        public RemoverClienteResponse(int id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }
    }
}
