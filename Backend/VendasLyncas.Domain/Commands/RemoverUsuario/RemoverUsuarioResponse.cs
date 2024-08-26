using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasLyncas.Domain.Commands.RemoverUsuario
{
    public class RemoverUsuarioResponse
    {
        public int Id { get; }
        public string Mensagem { get; }

        public RemoverUsuarioResponse(int id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }
    }
}
