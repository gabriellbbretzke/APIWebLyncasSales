import { ApiService } from "./api.service.js";

//*********************************************************************************************************/
//--------------***************************TELA DE LISTA DE VENDAS***************************--------------

//-----------------------------------------LISTA VENDAS EM TELA COM FETCH API. 
export async function listarVendas () {
    var consultaVenda = await ApiService.get('Venda');
    inserirDadosTabelaVendas(consultaVenda.dados.listadeVendas);
    return consultaVenda.dados.listadeVendas;
}
//-----------------------------------------ITERAÇÃO PARA CRIAR LINHAS NA TABELA PARA EXIBIR CLIENTES.
function inserirDadosTabelaVendas(dadosVendas){
    const conteudoTabela = document.querySelector('[data-tabela]');
    for (let index = 0; index < dadosVendas.length; index++) 
        {
            conteudoTabela.appendChild(criarLinhaTabelaVendas(dadosVendas[index]));
        }
}
//-----------------------------------------CONTEÚDOS DAS LINHAS A SE CRIAR. 
const criarLinhaTabelaVendas = (dadosVenda) => {
    let linhaNovaVenda = document.createElement("tr");
    linhaNovaVenda.classList.add('linhatabela');
    let conteudo = `
                    <td class="primeiracolunatabela">${dadosVenda.clienteNome}</td>
                    <td>${dadosVenda.quantidadeItens}</td>
                    <td>${criarMascaraData(dadosVenda.dataVenda)}</td>
                    <td>${criarMascaraData(dadosVenda.dataFaturamento)}</td>
                    <td>${dadosVenda.valorTotal}</td>
                    <td class="ultimacolunatabela">
                        <button class="buttondeletar" onclick='removerVenda(${dadosVenda.id})'> Deletar </button>
                        <button class="buttoneditar"onclick='redirecionarPaginaEditarVenda(${dadosVenda.id})'> Editar </button>
                    </td>
                    `;
    linhaNovaVenda.innerHTML = conteudo; 
    return linhaNovaVenda;                      
};
//-----------------------------------------ALTERA FORMATO DA DATA PARA EXIBIÇÃO EM TELA 
function criarMascaraData(mascaraInput) {
    let valorInput = mascaraInput;
    let valorComPonto = valorInput.replace(/[^\d]/g, "").replace(/(\d{4})(\d{2})(\d{2})/, "$1/$2/$3").slice(0,10);
    return valorComPonto.split('/').reverse().join('/');
  }
//---------------------------------------REMOVER VENDA POR ID
export async function removerVenda(idVendaARemover) {
    const response = await ApiService.delete('Venda', idVendaARemover);
    console.log("Response: ", response);
    window.location.reload(true);
}
//-----------------------------------------REDIRECIONA PÁGINA PARA EDITAR VENDA. PASSA PARÂMETRO NA URL.
export function redirecionarPaginaEditarVenda(idVendaAEditar) {
    window.location = '/Frontend/cadastrodevendas.html?id='+idVendaAEditar;
}


//*********************************************************************************************************/
//--------------***************************TELA DE CADASTRO DE VENDAS***************************--------------

//CONSTANTES E VARIÁVEIS GLOBAIS
const conteudoLista = document.querySelector('[data-listaCliente]');
const campoDataFaturamento = document.getElementById('datafaturamento');
var numeroUsuarioId = 5; //NÚMERO DO ID USUARIO DO SISTEMA. NESTE EXERCÍCIO OPÇÃO DE MUDAR USUÁRIO NÃO FOI CONTEMPLADA.

//----------------------MENU SUSPENSO DE LISTA DE CLIENTES
export async function listarClientesParaCadastroVenda () {
    var consultaCliente = await ApiService.get('Cliente');
    inserirDadosListaClientesParaVenda(consultaCliente.dados.listadeClientes);
    verificaIdParaAtualizarVendaNaPagina();
    return consultaCliente.dados.listadeClientes;
}
function inserirDadosListaClientesParaVenda(dadosClientes){
    for (let index = 0; index < dadosClientes.length; index++) 
        {
            if (dadosClientes[index].flagAtivo){
            conteudoLista.appendChild(criaListaDeCliente(dadosClientes[index]));
            }
        }
}
const criaListaDeCliente = (dadosCliente) => {
    let linhaNovoCliente = document.createElement("option");
    linhaNovoCliente.value = `${dadosCliente.id}`;
    linhaNovoCliente.innerHTML = `${dadosCliente.nome}`;
    return linhaNovoCliente;  
};
//----------------------AÇÃO DO BOTÃO SALVAR E CHECAR SE CRIAR UMA NOVA VENDA OU A ATUALIZA
export function checarOpcaoSalvarOuAtualizar (event){
    const parameters = new URLSearchParams(window.location.search);
    const vendaIdUrl = parameters.get('id');
    if (vendaIdUrl != null){
        atualizaVendaApi(vendaIdUrl);
        return (event.preventDefault());
    } else {
        criarVendaApi();
        return (event.preventDefault());
    }
}
//----------------------COMUNICAÇÃO API APÓS BOTÃO SALVAR
async function criarVendaApi() {
    var campoClienteId = parseInt(conteudoLista.value);
    const dataFaturamento = new Date(campoDataFaturamento.value).toISOString();
    const listaDeItensParaAPI = JSON.stringify(criaObjetoDeListaDeItens());
    const informacoes = `{
        "usuarioId": "${numeroUsuarioId}",
        "clienteId": "${campoClienteId}",
        "dataFaturamento": "${dataFaturamento}",
        "itens": ${listaDeItensParaAPI}
        }`;
    
    const response = await ApiService.post('Venda', informacoes);
    alert("Venda criada com Sucesso! \n\n\n" + informacoes);
}
//----------------------FORMA OBJETO PARA INCLUSÃO DE VÁRIOS ITENS E CRIAR/ATUALIZAR VENDA
function criaObjetoDeListaDeItens() {
    let campoDescricaoItens = document.querySelectorAll('#descitem');
    let campoValorUnitarioItens = document.querySelectorAll('#vlrunitario');
    let campoQuantidadeItens = document.querySelectorAll('#quantidade');

    const listaDeItem = [];
    for (let index = 0; index < campoDescricaoItens.length; index++) {
        let numeroValorUnitarioItens = ((Math.round(parseFloat(campoValorUnitarioItens[index].value.replace(",","."))*100))/100);
        let numeroQuantidadeItens = parseFloat(campoQuantidadeItens[index].value.replace(",","."));
        let numeroValorTotalItens = ((Math.round(numeroValorUnitarioItens*100)) * numeroQuantidadeItens)/100;

        listaDeItem[index] = {
                "descricao": `${campoDescricaoItens[index].value}`,
                "valor": `${numeroValorUnitarioItens}`,
                "quantidade": `${numeroQuantidadeItens}`,
                "totalItensVenda": `${numeroValorTotalItens}`
            };        
    }
    return listaDeItem;
}
//----------------------PREENCHE CAMPO TOTAL DO ITEM, AO CARREGAR PÁGINA E SOMA TOTAL
export function somarTotalItemETotalValorTela () {
    let campoVlrUnitario = document.querySelectorAll('#vlrunitario');
    let quantidadeItem= document.querySelectorAll('#quantidade');
    let campoVlrTotal = document.querySelectorAll('#vlrtotal');
    
    for (let indexCampo = 0; indexCampo < campoVlrUnitario.length; indexCampo++) {
        campoVlrUnitario[indexCampo].addEventListener('focusout', () => {            
            somaValorTotalPorItem (campoVlrUnitario[indexCampo], quantidadeItem[indexCampo], campoVlrTotal[indexCampo]);
        });
        quantidadeItem[indexCampo].addEventListener('focusout', () => {
            somaValorTotalPorItem (campoVlrUnitario[indexCampo], quantidadeItem[indexCampo], campoVlrTotal[indexCampo]);
        });
    }    
}
function somaValorTotalPorItem (elementVlr, elementQtde, elementoVlrTotal) {
    if (elementVlr.value != '' && elementQtde.value != ''){
        var a = Math.round((parseFloat(elementVlr.value.replace(",",".")))*100);
        var b = parseFloat(elementQtde.value.replace(",","."));
        var multiplicacao = ((a*b)/100);
        elementoVlrTotal.value = multiplicacao.toString().replace(".",",");
        somaValoresParaTela();
    }
    else {
        elementoVlrTotal.value = '0,00';
    }
}
function somaValoresParaTela() {
    let camposValoresTotaisItens = document.querySelectorAll('#vlrtotal');
    let campoSomaValorTotal = document.getElementById('caixa_total__soma');
    let somaTotal = 0.0;
    for (let index = 0; index < camposValoresTotaisItens.length; index++) {
        var element = (parseFloat(camposValoresTotaisItens[index].value.replace(',','.')));
        somaTotal += element;
        somaTotal = ((Math.round(somaTotal*100))/100);
        campoSomaValorTotal.innerHTML = "Total: R$ " + somaTotal.toString().replace('.',',');
    }
}
//----------------------BOTÃO + MAIS ITENS => VERIFICA SE PRIMEIRO ITEM NA LINHA ESTÁ PREENCHIDO
export function verificarOpcaoDeMaisItensParaAdicionar(event){
    const campoDescItem = document.getElementById('descitem');
    if (campoDescItem.value != ''){
        criarNovasLinhasDeItens();
        return (event.preventDefault());
    } else {
        return (event.preventDefault());
    }
}
//----------------------BOTÃO + MAIS ITENS => CRIA MAIS LINHAS DE ITENS
function criarNovasLinhasDeItens(){
    var caixaItens = document.querySelector('[data-caixaitempedido]');
    var criarLinhaItem = document.createElement("div");
    criarLinhaItem.classList.add('linha');
    criarLinhaItem.classList.add('item');
    const conteudo = `
                    <div class="coluna item"> 
                        <label for="descitem">Descrição do item</label>
                        <input class="input-padrao campo item" type="text" id="descitem" required>
                    </div>
                    <div class="coluna valores">
                        <div class="coluna valor"> 
                        <label for="vlrunitario" >Valor unitário</label>
                        <input class="input-padrao campo vlrunitario" type="text" id="vlrunitario" onchange="criarMascaraValorUnitario(this.value)" maxlength="11" required>
                        </div>
                        <div class="coluna quantidade"> 
                        <label for="quantidade">Quantidade</label>
                        <input class="input-padrao campo quantidade" type="number" step="1" id="quantidade" min="1" required>
                        </div>
                        <div class="coluna valor"> 
                        <label for="vlrtotal">Valor total</label>
                        <input class="input-padrao campo vlrtotal" type="text" id="vlrtotal" disabled>
                        </div>
                    </div>
                    `;
    criarLinhaItem.innerHTML = conteudo;
    caixaItens.appendChild(criarLinhaItem);
    return;
}
//----------------------CARREGA INFORMAÇÕES DE EDIÇÃO DE VENDA NA PÁGINA VIA ID NA URL
function verificaIdParaAtualizarVendaNaPagina (event) {
    const parameters = new URLSearchParams(window.location.search);
    const vendaIdUrl = parameters.get('id');
    if (vendaIdUrl != null){
        conectaApiParaVendaId(vendaIdUrl);
    }
}
async function conectaApiParaVendaId(vendaIdUrl){
        var consultaVenda = await ApiService.getByID('Venda', vendaIdUrl);
        carregaInformacoesDaVendaNaPagina(consultaVenda.dados);
}
function carregaInformacoesDaVendaNaPagina(dadosVenda){
    for (let i = 0; i < conteudoLista.options.length; i++) {
        if(conteudoLista.options[i].value == dadosVenda.clienteId){
            conteudoLista.selectedIndex = i;
            break;
        }
    }
    campoDataFaturamento.value = dadosVenda.dataFaturamento.toString().slice(0,10);
    
    for (let index = 0; index < dadosVenda.itens.length; index++) {
        if (index != 0){
            criarNovasLinhasDeItens();        
        }
        let campoDescricaoItens = document.querySelectorAll('#descitem');
        let campoValorUnitarioItens = document.querySelectorAll('#vlrunitario');
        let campoQuantidadeItens = document.querySelectorAll('#quantidade');
        let elementoVlrTotal = document.querySelectorAll('#vlrtotal');

        campoDescricaoItens[index].value = dadosVenda.itens[index].descricao;
        campoValorUnitarioItens[index].value = JSON.stringify(dadosVenda.itens[index].valor).replace('.',',');
        campoQuantidadeItens[index].value = dadosVenda.itens[index].quantidade;
        var a = parseFloat(dadosVenda.itens[index].valor);
        var b = parseFloat(dadosVenda.itens[index].quantidade);
        var multiplicacao = a * b;
        elementoVlrTotal[index].value = multiplicacao.toString().replace(".",",");

        somaValoresParaTela();
    }
}
//----------------------ATUALIZAR VENDA API
async function atualizaVendaApi(idVendaUrl){
    const dataFaturamento = new Date(campoDataFaturamento.value).toISOString();
    const listaDeItensParaAPI = JSON.stringify(criaObjetoDeListaDeItens());
    const informacoes = `{
        "id": "${idVendaUrl}",
        "usuarioId": "${numeroUsuarioId}",
        "clienteId": "${parseInt(conteudoLista.value)}",
        "dataFaturamento": "${dataFaturamento}",
        "itens": ${listaDeItensParaAPI}
        }`;
    const response = await ApiService.put('Venda', informacoes);
    alert("Venda atualizada com Sucesso! \n\n\n" + JSON.stringify(response, null, 5));
}
//----------------------VERIFICAR SE EXISTE APENAS UM CAMPO ITEM PARA NÃO REMOVER
export function verificarOpcaoDeUmItemParaRemover(event){
    const campoDescItem = document.querySelectorAll('#descitem');
    if (campoDescItem.length != 1){
        removerItemDaLista();
        return;
    } else {
        return;
    }
}
//----------------------REMOVER ITEM DA LISTA AO CADASTRAR/EDITAR VENDA
function removerItemDaLista(){
    var caixaItens = document.querySelector('[data-caixaitempedido]');
    var ultimoItem = caixaItens.lastChild;
    caixaItens.removeChild(ultimoItem);
    return;
}