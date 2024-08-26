using MediatR;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.Commands.AtualizarCliente;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.CrossCutting.Constants;

namespace VendasLyncas.Domain.Commands.ObterVenda
{
    public class ObterVendaHandler : Notifiable, IRequestHandler<ObterVendaRequest, CommandResponse>
    {
        private readonly IRepositoryVenda _repositoryVenda;

        public ObterVendaHandler(IRepositoryVenda repositoryVenda)
        {
            _repositoryVenda = repositoryVenda;
        }

        public Task<CommandResponse> Handle(ObterVendaRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification(Notificacoes.VENDA_MODULO, Notificacoes.REQUEST_INVALIDO);
                return Task.FromResult(new CommandResponse(this));
            }

            var venda = _repositoryVenda.ObterComItemVenda(request.Id);
            
            if (venda is null)
            {
                AddNotification(Notificacoes.VENDA_MODULO, Notificacoes.VENDA_NAO_LOCALIZADA);
                return Task.FromResult(new CommandResponse(this));
            }
            AddNotifications(venda);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            return Task.FromResult(new CommandResponse(
                new ObterVendaResponse(
                    venda.Id, venda.UsuarioId, venda.ClienteId, venda.DataFaturamento, venda.Itens.ToList()), this));
        }
    }
}
