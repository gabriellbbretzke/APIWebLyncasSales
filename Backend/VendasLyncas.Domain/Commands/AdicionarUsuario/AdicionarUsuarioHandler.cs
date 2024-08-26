using MediatR;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.CrossCutting.Constants;

namespace VendasLyncas.Domain.Commands.AdicionarUsuario
{
    public class AdicionarUsuarioHandler : Notifiable, IRequestHandler<AdicionarUsuarioRequest, CommandResponse>
    {
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AdicionarUsuarioHandler(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public Task<CommandResponse> Handle(AdicionarUsuarioRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                AddNotification(Notificacoes.USUARIO_MODULO, Notificacoes.REQUEST_INVALIDO);
                return Task.FromResult(new CommandResponse(this));
            }

            var usuario = new Usuario(request.Email, request.Senha, request.PerfilAcesso);
            AddNotifications(usuario);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryUsuario.Adicionar(usuario);
            _repositoryUsuario.Commit();

            return Task.FromResult(new CommandResponse(new AdicionarUsuarioResponse(usuario.Id, Notificacoes.USUARIO_REGISTRADO), this));
        }
    }
}
