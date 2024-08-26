using MediatR;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.CrossCutting.Constants;

namespace VendasLyncas.Domain.Commands.AdicionarVenda
{
    public class AdicionarVendaHandler : Notifiable, IRequestHandler<AdicionarVendaRequest, CommandResponse>
    {
        private readonly IRepositoryVenda _repositoryVenda;
        private readonly IRepositoryCliente _repositoryCliente;
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AdicionarVendaHandler(IRepositoryVenda repositoryVenda, IRepositoryCliente repositoryCliente, IRepositoryUsuario repositoryUsuario)
        {
            _repositoryVenda = repositoryVenda;
            _repositoryCliente = repositoryCliente;
            _repositoryUsuario = repositoryUsuario;
        }

        public Task<CommandResponse> Handle(AdicionarVendaRequest request, CancellationToken cancellationToken)
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

            var venda = new Venda(request.UsuarioId, request.ClienteId, request.Itens.Count, request.DataFaturamento, request.Itens.Sum(p => p.TotalItensVenda));

            request.Itens.ForEach(itemVenda =>
            {
                venda.AdicionarItem(new ItemVenda(itemVenda.Descricao, itemVenda.Valor, itemVenda.Quantidade, itemVenda.TotalItensVenda));
            });

            AddNotifications(venda);
            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryVenda.Adicionar(venda);
            _repositoryVenda.Commit();

            return Task.FromResult(new CommandResponse(new AdicionarVendaResponse(venda.Id, Notificacoes.VENDA_REGISTRADA), this));
        }
    }
}
