using MediatR;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.Commands.ObterCliente;
using VendasLyncas.Domain.Commands.RemoverCliente;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.CrossCutting.Constants;

namespace VendasLyncas.Domain.Commands.AtualizarCliente
{
    public class RemoverClienteHandler : Notifiable, IRequestHandler<RemoverClienteRequest, CommandResponse>
    {
        private readonly IRepositoryCliente _repositoryCliente;
        
        public RemoverClienteHandler(IRepositoryCliente repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }

        public Task<CommandResponse> Handle(RemoverClienteRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                AddNotification(Notificacoes.CLIENTE_MODULO, Notificacoes.REQUEST_INVALIDO);
                return Task.FromResult(new CommandResponse(this));
            }

            var cliente = _repositoryCliente.Obter(request.Id);
            if (cliente is null)
            {
                AddNotification(Notificacoes.CLIENTE_MODULO, Notificacoes.CLIENTE_NAO_LOCALIZADO);
                return Task.FromResult(new CommandResponse(this));
            }
            AddNotifications(cliente);  

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            //_repositoryCliente.Remover(cliente);
            cliente.Inativar();
            _repositoryCliente.Commit();

            return Task.FromResult(new CommandResponse(new RemoverClienteResponse(request.Id, Notificacoes.CLIENTE_REMOVIDO), this));
        }
    }
}
