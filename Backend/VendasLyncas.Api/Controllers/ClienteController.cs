using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Linq;
using VendasLyncas.Domain.Commands.AdicionarCliente;
using VendasLyncas.Domain.Commands.AtualizarCliente;
using VendasLyncas.Domain.Commands.ListarCliente;
using VendasLyncas.Domain.Commands.ObterCliente;
using VendasLyncas.Domain.Commands.RemoverCliente;
using VendasLyncas.Domain.DTOs;

namespace VendasLyncas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        [HttpGet]
        public Task<CommandResponse> ListaClientes([FromServices] IMediator _mediator)
        {
            return _mediator.Send(new ListarClienteRequest());
        }

        [HttpGet("{id}")]
        public Task<CommandResponse> ObtemCliente([FromServices] IMediator _mediator, int id)
        {
            var obterCliente = new ObterClienteRequest { Id = id };
            return _mediator.Send(obterCliente);
        }

        [HttpPost]
        public async Task<CommandResponse> AdicionaCliente([FromServices]IMediator _mediator,[FromBody] AdicionarClienteRequest cadastrarCliente)
        {
            var response = await _mediator.Send(cadastrarCliente);
            return response;
        }

        [HttpPut]
        public async Task<CommandResponse> AtualizaCliente([FromServices] IMediator _mediator, [FromBody] AtualizarClienteRequest atualizarCliente)
        {
            var response = await _mediator.Send(atualizarCliente);
            return response;
        }

        [HttpDelete("{id}")] 
        public async Task<CommandResponse> RemoveCliente([FromServices] IMediator _mediator, int id)
        {
            var removerCliente = new RemoverClienteRequest { Id = id };
            return await _mediator.Send(removerCliente);
        }

        //[HttpGet("Palavra")]
        //public List<string> ListaDePalavaras()
        //{
        //    List<string> palavras = new List<string> {
        //                            "Administracao",
        //                            "Arrendatario",
        //                            "Auditoria",
        //                            "Banco",
        //                            "Cadastros",
        //                            "CadastrosAuxiliares",
        //                            "CaixaDeEntrada",
        //                            "Caracteristica",
        //                            "Cargos",
        //                            "Cemiterio",
        //                            "Cidade",
        //                            "Classe",
        //                            "Classificacao",
        //                            "Contribuicao",
        //                            "Colecoes",
        //                            "Culto",
        //                            "Estado",
        //                            "Evento",
        //                            "ExibirVisualizacoes",
        //                            "GabaritoDons",
        //                            "Gestao",
        //                            "Migracao",
        //                            "Ministerio",
        //                            "Organizacao",
        //                            "OrganizacaoCampoTrabalho",
        //                            "OrganizacaoContaBancaria",
        //                            "OrganizacaoContato",
        //                            "OrganizacaoDadosGerais",
        //                            "OrganizacaoEndereco",
        //                            "OrganizacaoHistoricoAtualizacao",
        //                            "OrganizacaoListagem",
        //                            "OrganizacaoNova",
        //                            "OrganizacaoPessoaEmAtividade",
        //                            "OrganizacaoPessoa",
        //                            "OrganizacaoPessoaAssociarPerfil",
        //                            "Parametros",
        //                            "Perfil",
        //                            "Permissoes",
        //                            "Pessoa",
        //                            "PessoaAtividade",
        //                            "PessoaAtividadeRepresentativa",
        //                            "PessoaCasamento",
        //                            "PessoaContaBancaria",
        //                            "PessoaContato",
        //                            "PessoaDadosGerais",
        //                            "PessoaEndereco",
        //                            "PessoaEventoOficio",
        //                            "PessoaFamilia",
        //                            "PessoaFormacao",
        //                            "PessoaHistoricoAtualizacoes",
        //                            "PessoaHistoricoProfissional",
        //                            "PessoaIntegracaoDesligamento",
        //                            "PessoaListagem",
        //                            "PessoaMinistro",
        //                            "PessoaNovo",
        //                            "PessoaQualificacoes",
        //                            "PessoaRendaContribuicao",
        //                            "Profissao",
        //                            "RelatorioNovo",
        //                            "Setor",
        //                            "Situacao",
        //                            "Solicitacao",
        //                            "TesteDons",
        //                            "Ticket",
        //                            "TicketManager",
        //                            "TicketCategoria",
        //                            "TicketListagem",
        //                            "Time",
        //                            "Triagem",
        //                            "TipoCampoTrabalho",
        //                            "TipoCelebracaoOficio",
        //                            "TipoEvento",
        //                            "TipoOrganizacao",
        //                            "TipoPessoa",
        //                            "Usuario",
        //                            "Visualizacoes"};
        //    List<string> cadaPalavra = new List<String>();
        //    //string[] maiusculas = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Z"};
        //    foreach (string palavra in palavras)
        //    {
        //        cadaPalavra = palavra.Split(' ').Where(x => String.Equals(x, x.ToUpper(), StringComparison.Ordinal)).ToList();
        //    }
        //    return cadaPalavra;
        //}
    }
}
