using MediatR;
using VendasLyncas.Domain.DTOs;

namespace VendasLyncas.Domain.Commands.AdicionarUsuario
{
    public class AdicionarUsuarioRequest : IRequest<CommandResponse>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string PerfilAcesso { get; set; }
    }
}
