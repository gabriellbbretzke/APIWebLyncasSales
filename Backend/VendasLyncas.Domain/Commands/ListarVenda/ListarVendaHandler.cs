using MediatR;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.DTOs;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.CrossCutting.Constants;

namespace VendasLyncas.Domain.Commands.ListarVenda
{
    public class ListarVendaHandler : Notifiable, IRequestHandler<ListarVendaRequest, CommandResponse>
    {
        private readonly IRepositoryVenda _repositoryVenda;

        public ListarVendaHandler(IRepositoryVenda repositoryVenda, IRepositoryCliente respositoryCliente)
        {
            _repositoryVenda = repositoryVenda;
        }

        public Task<CommandResponse> Handle(ListarVendaRequest request, CancellationToken cancellationToken)
        {
            List<Venda> vendas = _repositoryVenda.ListarComItemVenda().ToList();

            List<ListarVendaDTO> vendasDTO = new List<ListarVendaDTO>();

            vendas.ForEach(p =>
            {
                vendasDTO.Add(new ListarVendaDTO
                {
                    Id = p.Id,
                    UsuarioId = p.UsuarioId,
                    ClienteId = p.ClienteId,
                    ClienteNome = p.Cliente.Nome,
                    QuantidadeItens = p.QuantidadeItens,
                    DataVenda = p.DataVenda,
                    DataFaturamento = p.DataFaturamento,
                    ValorTotal = p.ValorTotal,
                    Itens = p.Itens
                }); ;
            });

            return Task.FromResult(new CommandResponse(new ListarVendaResponse(vendasDTO), this));

        }
    }
}
