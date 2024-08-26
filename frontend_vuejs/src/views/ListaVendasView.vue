<template>
    <!------ CONTEUDO ------>
    <div id="conteudo">
        <div id="caixa_titulo_pagina">
            <div id="titulo_pagina">
                <h1 class="listadevendas-titulo">Lista de vendas </h1>
            </div>
            <div id="campo_busca">
                <input type="search" name="buscapessoa" class="busca fontAwesome" placeholder=" Buscar pessoa..." />
                <RouterLink to="/cadastroVendas">
                    <button class="cadastrarcliente_botao">Cadastrar Venda</button>
                </RouterLink>
            </div>
        </div>
        <div class="conteudo_tabela">
            <table id="tabela">
                <thead>
                    <tr class="titulotabela2">
                        <th>Cliente</th>
                        <th>Qtd. itens</th>
                        <th>Data da venda</th>
                        <th>Data faturamento</th>
                        <th>Valor total</th>
                        <th>Ações</th>
                    </tr>
                </thead>
                <tbody data-tabela id="myList" v-for="venda in consultaVenda.dados.listadeVendas" :key="venda.id">
                    <tr class="linhatabela">
                        <td class="primeiracolunatabela">{{venda.clienteNome}}</td>
                        <td>{{venda.quantidadeItens}}</td>
                        <td v-mask="'##/##/####'">{{venda.dataVenda}}</td>
                        <td>{{venda.dataFaturamento}}</td>
                        <td>{{venda.valorTotal}}</td>
                        <td class="ultimacolunatabela">
                            <button class="buttondeletar" onclick='removerVenda({{venda.id}})'> Deletar </button>
                            <button class="buttoneditar" onclick='redirecionarPaginaEditarVenda({{venda.id}})'> Editar </button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
import { defineComponent } from 'vue'
import { ApiService } from '@/assets/js/api.service'

export default defineComponent({
  name: 'ListaVendas',
  data () {
    return {
      consultaVenda: []
    }
  },
  methods: {
    async listarVendas () {
      this.consultaVenda = await ApiService.get('Venda')
    }
  },
  beforeMount () {
    this.listarVendas()
  }
})
</script>
