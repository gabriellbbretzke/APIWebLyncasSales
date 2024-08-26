<template>
    <!------ CONTEUDO ------>
    <div id="conteudo">
        <div id="caixa_adicionar_cliente">
            <div id="titulo_pagina">
                <h1>Adicionar cliente</h1>
            </div>
            <form>
                <div class="linha_nome_email">
                    <div class="coluna_campos">
                        <label for="nomesobrenome" class="rotulo_nome">Nome</label>
                        <input type="text" id="nomesobrenome" class="input-padrao nome" name="nomesobrenome" required>
                    </div>

                    <div class="coluna_campos">
                        <label for="email" class="rotulo_email">Email</label>
                        <input type="email" id="email" class="input-padrao email" name="email" required>
                    </div>
                </div>
                <div class="linha_telefone_cpf">
                    <div class="coluna_campos">
                        <label for="telefone" class="rotulo_telefone">Telefone</label>
                        <input id="telefone" class="input-padrao telefone" type="tel" name="telefone"
                            pattern="[0-9]{3} [0-9]{5}-[0-9]{4}" title="Informar apenas os números" maxlength="12"
                            oninput="criaMascaraTelefone('telefone')" required>
                    </div>
                    <div class="coluna_campos">
                        <label for="CPF" class="rotulo_cpf">CPF</label>
                        <input id="CPF" class="input-padrao cpf" type="text" name="cpf" pattern="\d{3}\.\d{3}\.\d{3}-\d{2}"
                            title="Informar apenas os números" maxlength="11" oninput="criaMascaraCPF('CPF')" required>
                    </div>
                </div>
                <div id="caixa_botaosalvar">
                    <button class="botaosalvar" id="botaosalvar" onclick="verificarOpcaoPraSalvar()"> Salvar </button>
                </div>
                <div id="alerta"></div>
            </form>
        </div>
    </div>
</template>

<script>
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'CadastroClientes'
})
</script>
