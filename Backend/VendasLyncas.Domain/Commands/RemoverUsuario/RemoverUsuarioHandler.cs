using MediatR;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.Commands.RemoverUsuario;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.CrossCutting.Constants;

namespace VendasLyncas.Domain.Commands.AtualizarUsuario
{
    public class RemoverUsuarioHandler : Notifiable, IRequestHandler<RemoverUsuarioRequest, CommandResponse>
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        
        public RemoverUsuarioHandler(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public Task<CommandResponse> Handle(RemoverUsuarioRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
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

            _repositoryUsuario.Remover(usuario);
            _repositoryUsuario.Commit();

            return Task.FromResult(new CommandResponse(new RemoverUsuarioResponse(request.Id, Notificacoes.USUARIO_REMOVIDO), this));
        }
    }
}
