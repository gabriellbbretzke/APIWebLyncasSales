using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VendasLyncas.Domain.DTOs;

namespace VendasLyncas.Domain.Commands.AtualizarUsuario
{
    public class AtualizarUsuarioRequest : IRequest<CommandResponse>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string PerfilAcesso { get; set; }
    }
}
