using MediatR;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.CrossCutting.Constants;

namespace VendasLyncas.Domain.Commands.AdicionarCliente
{
    public class AdicionarClienteHandler : Notifiable, IRequestHandler<AdicionarClienteRequest, CommandResponse>
    {
        private readonly IRepositoryCliente _repositoryCliente;

        public AdicionarClienteHandler(IRepositoryCliente repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }

        public Task<CommandResponse> Handle(AdicionarClienteRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                AddNotification(Notificacoes.CLIENTE_MODULO, Notificacoes.REQUEST_INVALIDO);
                return Task.FromResult(new CommandResponse(this));
            }

            var cliente = new Cliente(request.Nome, request.Email, request.Telefone, request.Cpf);
            AddNotifications(cliente);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryCliente.Adicionar(cliente);
            _repositoryCliente.Commit();

            return Task.FromResult(new CommandResponse(new AdicionarClienteResponse(cliente.Id, Notificacoes.CLIENTE_REGISTRADO), this));
        }
    }
}
