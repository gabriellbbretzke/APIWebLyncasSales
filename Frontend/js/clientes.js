import { ApiService } from './api.service.js';

//CONSTANTES E VARIÁVEIS GLOBAIS
var campoNome = document.getElementById('nomesobrenome');
var campoEmail = document.getElementById('email')
var campoTelefone = document.getElementById('telefone')
var campoCpf = document.getElementById('CPF')
const botaoSalvar = document.getElementById('botaosalvar');

//*********************************************************************************************************/
//--------------***************************TELA DE LISTA DE CLIENTE***************************--------------

//-----------------------------------------LISTA CLIENTES EM TELA COM FETCH API. 
export async function listarClientes() {
    var consultaCliente = await ApiService.get('Cliente');
    inserirDadosTabela(consultaCliente.dados.listadeClientes);
    return consultaCliente.dados.listadeClientes;
}
//-----------------------------------------ITERAÇÃO PARA CRIAR LINHAS NA TABELA PARA EXIBIR CLIENTES.
function inserirDadosTabela(dadosClientes){
    const conteudoTabela = document.querySelector('[data-tabela]');
    if (conteudoTabela == null){ return; }
    for (let index = 0; index < dadosClientes.length; index++) 
        {
            if (dadosClientes[index].flagAtivo){
                conteudoTabela.appendChild(criarLinhaTabela(dadosClientes[index]));
            }
        }
    // adicionarFuncoesDeletarEEditarAsLinhas();
}
//-----------------------------------------CONTEÚDOS DAS LINHAS A SE CRIAR. 
const criarLinhaTabela = (dadosCliente) => {
        let linhaNovoCliente = document.createElement("tr");
        linhaNovoCliente.classList.add('linhatabela');
        let conteudo = `
                        <td class="primeiracolunatabela">${dadosCliente.nome}</td>
                            <td>${dadosCliente.email}</td>
                            <td>${dadosCliente.telefone}</td>
                            <td>${dadosCliente.cpf}</td>
                            <td class="ultimacolunatabela">
                                <button class="buttondeletar" onclick='removerCliente(${dadosCliente.id})'> Deletar </button>
                                <button class="buttoneditar" onclick='redirecionarPaginaEditarCliente(${dadosCliente.id})'> Editar </button>
                        </td>
                        `;
        linhaNovoCliente.innerHTML = conteudo; 
        return linhaNovoCliente;                      
};
//-----------------------------------------CHECAR SE CLIENTE ESTÁ ATRELADO A ALGUMA VENDA PARA EXCLUSÃO
export async function removerCliente (idClienteARemover) {
    //-----------VERIFICA SE USUÁRIO ESTÁ ATRELADO A ALGUMA VENDA PARA EVITAR EXCLUSÃO. 
    var consultaVenda = await ApiService.get('Venda');
    var resultado = consultaVenda.dados.listadeVendas.find(element => element.clienteId == idClienteARemover);
    if (resultado == undefined){
        removerClienteViaAPI(idClienteARemover);
    }
    else{
        alert ("Cliente com Venda registrada. Exclusão não permitida!");
        return;
    }
}
//-----------FUNÇÃO PARA COMUNICAÇÃO NORMAL VIA ENDPOINT DE EXCLUSÃO.
async function removerClienteViaAPI(idClienteARemover){
    const response = await ApiService.delete('Cliente', `${idClienteARemover}`);
    alert('Cliente removido com sucesso!');
    window.location.reload(true);
}
//-----------------------------------------REDIRECIONA PÁGINA PARA EDITAR USUÁRIO. PASSA PARÂMETRO NA URL.
export function redirecionarPaginaEditarCliente(idClienteAEditar) {
    window.location = '/Frontend/cadastrodeclientes.html?id='+idClienteAEditar;
}


//************************************************************************************************************/
//--------------***************************TELA DE CADASTRO DE CLIENTE***************************--------------
//-----------------------------------------CRIAR NOVO CLIENTE --> CADASTRO DE NOVO CLIENTE.
async function criarClienteApi() {
    const informacoes = `{
        "nome": "${campoNome.value}",
        "email": "${campoEmail.value}",
        "telefone": "${campoTelefone.value}",
        "cpf": "${campoCpf.value}"
    }`;
                
    const response = await ApiService.post('Cliente', informacoes);
}
//-----------------------------------------BOTÃO SALVAR CONTEÚDO --> VERIFICA SE EXISTE ID NA URL. CASO EXISTA ATUALIZARCLIENTE, CASO NÃO CRIAR NOVO CLIENTE.
export function verificarOpcaoPraSalvar() {
    const parameters = new URLSearchParams(window.location.search);
    const clienteIdUrl = parameters.get('id');
    if (clienteIdUrl != null){
        atualizarClienteApi(clienteIdUrl);
        alert('Cliente atualizado!');
    }
    else {
        criarClienteApi();
        alert('Cliente cadastrado!');
    }
}
//-----------------------------------------EDITAR CLIENTE --> ACIONA PREENCHIMENTO DAS INFORMAÇÕES CASO EXISTA ID DE CLIENTE NA URL
document.addEventListener("DOMContentLoaded", (event) => {
    const parameters = new URLSearchParams(window.location.search);
    const clienteIdUrl = parameters.get('id');
    if (clienteIdUrl != null){
        conectaApiParaClienteId(clienteIdUrl);
    }
    event.preventDefault();
});

async function conectaApiParaClienteId(clienteIdUrl) {    
    var consultaCliente = await ApiService.getByID('Cliente', clienteIdUrl);
    carregaInformacoesDoClienteNaPagina(consultaCliente.dados);
}

function carregaInformacoesDoClienteNaPagina(dadosCliente){
    campoNome.value = dadosCliente.nome;
    campoEmail.value = dadosCliente.email;
    campoTelefone.value = dadosCliente.telefone;
    campoCpf.value = dadosCliente.cpf;
    return;
}
//-----------------------------------------FUNÇÃO DE ATUALIZAR CLIENTE -> ATUALIZA INFORMAÇÕES DO CLIENTE DA PÁGINA.
async function atualizarClienteApi(idClienteUrl) {
    const informacoes = `{
        "id": "${idClienteUrl}",
        "nome": "${campoNome.value}",
        "email": "${campoEmail.value}",
        "telefone": "${campoTelefone.value}",
        "cpf": "${campoCpf.value}"
    }`;
    const response = await ApiService.put('Cliente', informacoes);
}
//************************************************************************************************************/