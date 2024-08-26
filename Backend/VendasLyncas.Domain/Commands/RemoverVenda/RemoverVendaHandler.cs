using MediatR;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.Commands.ObterCliente;
using VendasLyncas.Domain.Commands.RemoverCliente;
using VendasLyncas.Domain.Commands.RemoverVenda;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.CrossCutting.Constants;

namespace VendasLyncas.Domain.Commands.AtualizarVenda
{
    public class RemoverVendaHandler : Notifiable, IRequestHandler<RemoverVendaRequest, CommandResponse>
    {
        private readonly IRepositoryVenda _repositoryVenda;
        
        public RemoverVendaHandler(IRepositoryVenda repositoryVenda)
        {
            _repositoryVenda = repositoryVenda;
        }

        public Task<CommandResponse> Handle(RemoverVendaRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                AddNotification(Notificacoes.VENDA_MODULO, Notificacoes.REQUEST_INVALIDO);
                return Task.FromResult(new CommandResponse(this));
            }

            var venda = _repositoryVenda.Obter(request.Id);
            if (venda is null)
            {
                AddNotification(Notificacoes.VENDA_MODULO, Notificacoes.VENDA_NAO_LOCALIZADA);
                return Task.FromResult(new CommandResponse(this));
            }

            //REMOVER ITENS DA VENDA ANTES DE REMOVER A VENDA. 
            venda.Itens.ToList().ForEach(itemVenda =>
            {
                venda.RemoverItem(new ItemVenda(itemVenda.Descricao, itemVenda.Valor, itemVenda.Quantidade, itemVenda.TotalItensVenda));
            });

            AddNotifications(venda);  
            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryVenda.Remover(venda);
            _repositoryVenda.Commit();

            return Task.FromResult(new CommandResponse(new RemoverVendaResponse(request.Id, Notificacoes.VENDA_REMOVIDO), this));
        }
    }
}
