using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasLyncas.Domain.Commands.AtualizarUsuario
{
    public class AtualizarUsuarioResponse
    {
        public int Id { get; }
        public string Mensagem { get; }

        public AtualizarUsuarioResponse(int id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }
    }
}
