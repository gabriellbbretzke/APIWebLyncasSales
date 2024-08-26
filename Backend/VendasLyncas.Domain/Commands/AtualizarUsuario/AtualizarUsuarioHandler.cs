using MediatR;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.CrossCutting.Constants;

namespace VendasLyncas.Domain.Commands.AtualizarUsuario
{
    public class AtualizarUsuarioHandler : Notifiable, IRequestHandler<AtualizarUsuarioRequest, CommandResponse>
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        
        public AtualizarUsuarioHandler(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public Task<CommandResponse> Handle(AtualizarUsuarioRequest request, CancellationToken cancellationToken)
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

            usuario.Atualizar(request.Email, request.Senha, request.PerfilAcesso);
            AddNotifications(usuario);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryUsuario.Atualizar(usuario);
            _repositoryUsuario.Commit();

            return Task.FromResult(new CommandResponse(new AtualizarUsuarioResponse(usuario.Id, Notificacoes.USUARIO_ATUALIZADO), this));
        }
    }
}
