using MediatR;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;

namespace VendasLyncas.Domain.Commands.ListarUsuario
{
    public class ListarUsuarioHandler : Notifiable, IRequestHandler<ListarUsuarioRequest, CommandResponse>
    {
        private readonly IRepositoryUsuario _repositoryUsuario;

        public ListarUsuarioHandler(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public Task<CommandResponse> Handle(ListarUsuarioRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Usuario> usuarios = _repositoryUsuario.Listar();

            return Task.FromResult(new CommandResponse(new ListarUsuarioResponse(usuarios), this));

        }
    }
}
