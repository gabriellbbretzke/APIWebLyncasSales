using MediatR;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.CrossCutting.Constants;

namespace VendasLyncas.Domain.Commands.ListarCliente
{
    public class ListarClienteHandler : Notifiable, IRequestHandler<ListarClienteRequest, CommandResponse>
    {
        private readonly IRepositoryCliente _repositoryCliente;

        public ListarClienteHandler(IRepositoryCliente repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }

        public Task<CommandResponse> Handle(ListarClienteRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Cliente> clientes = _repositoryCliente.Listar();

            return Task.FromResult(new CommandResponse(new ListarClienteResponse(clientes), this));

        }
    }
}
