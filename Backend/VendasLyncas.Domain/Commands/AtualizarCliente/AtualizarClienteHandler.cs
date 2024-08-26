using MediatR;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.Commands.ObterCliente;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.CrossCutting.Constants;

namespace VendasLyncas.Domain.Commands.AtualizarCliente
{
    public class AtualizarClienteHandler : Notifiable, IRequestHandler<AtualizarClienteRequest, CommandResponse>
    {
        private readonly IRepositoryCliente _repositoryCliente;
        
        public AtualizarClienteHandler(IRepositoryCliente repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }

        public Task<CommandResponse> Handle(AtualizarClienteRequest request, CancellationToken cancellationToken)
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
            cliente.Atualizar(request.Nome, request.Email, request.Telefone, request.Cpf);
            AddNotifications(cliente);  

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryCliente.Atualizar(cliente);
            _repositoryCliente.Commit();

            return Task.FromResult(new CommandResponse(new AtualizarClienteResponse(cliente.Id, Notificacoes.CLIENTE_ATUALIZADO), this));
        }
    }
}
