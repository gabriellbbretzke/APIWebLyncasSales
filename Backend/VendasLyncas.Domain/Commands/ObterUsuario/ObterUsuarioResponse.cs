using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasLyncas.Domain.Entities;

namespace VendasLyncas.Domain.Commands.ObterUsuario
{
    public class ObterUsuarioResponse
    {
        public int Id { get; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string PerfilAcesso { get; private set; }

        public ObterUsuarioResponse(int id, string email, string senha, string perfilDeAcesso)
        {
            Id = id;
            Email = email;
            Senha = senha;
            PerfilAcesso = perfilDeAcesso;
        }
    }
}
