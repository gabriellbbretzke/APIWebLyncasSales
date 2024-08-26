<template>
    <div id="conteudo">
        <div id="caixa_titulo_pagina">
            <div id="titulo_pagina">
                <h1 class="listadeclientes-titulo">Lista de clientes </h1>
            </div>
            <div id="campo_busca">
                <input type="search" name="buscapessoa" class="busca fontAwesome" placeholder=" Buscar pessoa..."/>
                <RouterLink to="/cadastroClientes">
                    <button class="cadastrarcliente_botao">
                        Cadastrar Cliente
                    </button>
                </RouterLink>
            </div>
        </div>
        <div class="conteudo_tabela" id="erro">
            <table id="tabela">
                <thead>
                    <tr class="titulotabela2">
                        <th>Nome</th>
                        <th>E-mail</th>
                        <th>Telefone</th>
                        <th>CPF</th>
                        <th>Ações</th>
                    </tr>
                </thead>
                <tbody data-tabela id="myList" v-for="cliente in consultaCliente.dados.listadeClientes" :key="cliente.id">
                    <tr class="linhatabela">
                        <td class="primeiracolunatabela">{{cliente.nome}}</td>
                        <td>{{cliente.email}}</td>
                        <td>{{cliente.telefone}}</td>
                        <td>{{cliente.cpf}}</td>
                        <td class="ultimacolunatabela">
                            <button class="buttondeletar" onclick='removerCliente({{cliente.id}})'> Deletar </button>
                            <button class="buttoneditar" onclick='redirecionarPaginaEditarCliente({{cliente.id}})'> Editar </button>
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
  name: 'ListaClientes',
  data () {
    return {
      consultaCliente: []
    }
  },
  methods: {
    async listarClientes () {
      this.consultaCliente = await ApiService.get('Cliente')
    }
  },
  beforeMount () {
    this.listarClientes()
  }
})
</script>

<style>

</style>
