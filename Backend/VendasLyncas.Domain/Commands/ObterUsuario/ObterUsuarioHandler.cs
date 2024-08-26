using MediatR;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.Commands.AtualizarUsuario;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.CrossCutting.Constants;

namespace VendasLyncas.Domain.Commands.ObterUsuario
{
    public class ObterUsuarioHandler : Notifiable, IRequestHandler<ObterUsuarioRequest, CommandResponse>
    {
        private readonly IRepositoryUsuario _repositoryUsuario;

        public ObterUsuarioHandler(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public Task<CommandResponse> Handle(ObterUsuarioRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification(Notificacoes.USUARIO_MODULO, Notificacoes.REQUEST_INVALIDO);
                return Task.FromResult(new CommandResponse(this));
            }

            var usuario = _repositoryUsuario.Obter(request.Id);
            if (usuario is null)
            {
                AddNotification(Notificacoes.USUARIO_MODULO, Notificacoes.USUARIO_NAO_LOCALIZADO);
                return Task.FromResult(new CommandResponse(this));
            }

            AddNotifications(usuario);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            return Task.FromResult(new CommandResponse(new ObterUsuarioResponse(request.Id, usuario.Email, usuario.Senha, usuario.PerfilAcesso), this));

        }
    }
}
