using MediatR;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.Commands.AtualizarCliente;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.CrossCutting.Constants;

namespace VendasLyncas.Domain.Commands.ObterCliente
{
    public class ObterClienteHandler : Notifiable, IRequestHandler<ObterClienteRequest, CommandResponse>
    {
        private readonly IRepositoryCliente _repositoryCliente;

        public ObterClienteHandler(IRepositoryCliente repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }

        public Task<CommandResponse> Handle(ObterClienteRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
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

            //CHECAR O QUE FAZER QUANDO USUÁRIO NÃO EXISTE.
            AddNotifications(cliente);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            return Task.FromResult(new CommandResponse(new ObterClienteResponse(request.Id, cliente.Nome, cliente.Email, cliente.Telefone, cliente.Cpf, cliente.FlagAtivo), this));

        }
    }
}
