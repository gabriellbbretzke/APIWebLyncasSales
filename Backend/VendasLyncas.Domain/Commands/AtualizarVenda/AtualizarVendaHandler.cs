using MediatR;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.Commands.ObterVenda;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.CrossCutting.Constants;

namespace VendasLyncas.Domain.Commands.AtualizarVenda
{
    public class AtualizarVendaHandler : Notifiable, IRequestHandler<AtualizarVendaRequest, CommandResponse>
    {
        private readonly IRepositoryVenda _repositoryVenda;
        private readonly IRepositoryCliente _repositoryCliente;
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AtualizarVendaHandler(IRepositoryVenda repositoryVenda, IRepositoryCliente repositoryCliente, IRepositoryUsuario repositoryUsuario)
        {
            _repositoryVenda = repositoryVenda;
            _repositoryCliente = repositoryCliente;
            _repositoryUsuario = repositoryUsuario;
        }


        public Task<CommandResponse> Handle(AtualizarVendaRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                AddNotification(Notificacoes.VENDA_MODULO, Notificacoes.REQUEST_INVALIDO);
                return Task.FromResult(new CommandResponse(this));
            }

            var usuario = _repositoryUsuario.Obter(request.UsuarioId);
            if (usuario == null)
                AddNotification(Notificacoes.USUARIO_MODULO, Notificacoes.USUARIO_NAO_LOCALIZADO);

            var cliente = _repositoryCliente.Obter(request.ClienteId);
            if (cliente == null)
                AddNotification(Notificacoes.VENDA_MODULO, Notificacoes.CLIENTE_NAO_LOCALIZADO);

            var venda = _repositoryVenda.ObterComItemVenda(request.Id);
            if (venda is null)
            {
                AddNotification(Notificacoes.VENDA_MODULO, Notificacoes.VENDA_NAO_LOCALIZADA);
                return Task.FromResult(new CommandResponse(this));
            }

            venda.AtualizarVenda(request.UsuarioId, request.ClienteId, request.Itens.Count, request.DataFaturamento, request.Itens.Sum(p => p.TotalItensVenda));

            venda.Itens.ToList().ForEach(itemVenda => venda.RemoverItem(itemVenda));

            request.Itens.ForEach(itemVenda =>
            {
                venda.AdicionarItem(new ItemVenda(itemVenda.Descricao, itemVenda.Valor, itemVenda.Quantidade, itemVenda.TotalItensVenda));
            });

            AddNotifications(venda);  

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryVenda.Atualizar(venda);
            _repositoryVenda.Commit();

            return Task.FromResult(new CommandResponse(new AtualizarVendaResponse(venda.Id, Notificacoes.VENDA_ATUALIZADA), this));
        }
    }
}
