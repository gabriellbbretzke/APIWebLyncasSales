<template>
      <!------ CONTEUDO ------>
      <div id="caixa_adicionar_venda">
        <div id="titulo_pagina">
            <h1>Adicionar venda</h1>
        </div>
        <form>
          <div class="linha cliente caixa__cliente">
            <div class="coluna cliente">
              <label>Cliente</label>
              <select autofocus required data-listaCliente id="ListaCliente">
                <option></option>
              </select>
            </div>
            <div class="coluna datafaturamento">
              <label for="datafaturamento" >Data de faturamento</label>
              <input class="input-padrao campo datafaturamento" type="date" id="datafaturamento" pattern="[0-9]{2}/[0-9]{2}/[0-9]{4}" min="1990-01-01" max="2050-12-31" required>
            </div>
          </div>
          <div>
            <h3>Itens do pedido</h3>
              <div class="caixa__itempedido">
                <div class="lista itens" data-caixaitempedido>
                  <div class="linha item">
                      <div class="coluna item">
                        <label for="descitem">Descrição do item</label>
                        <input class="input-padrao campo item" type="text" id="descitem" required>
                      </div>
                      <div class="coluna valores">
                        <div class="coluna valor">
                          <label for="vlrunitario" >Valor unitário</label>
                          <input class="input-padrao campo vlrunitario" type="text" id="vlrunitario" onchange="criarMascaraValorUnitario()" maxlength="11" required>
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
                  </div>
                </div>
                <div id="caixa_botaoadicionaitem">
                  <button class="buttondeletar" id="button_deletarItem" onclick='verificarOpcaoDeUmItemParaRemover()'> Remover item </button>
                  <button id="venda__botaoadicionaitem" onclick="verificarOpcaoDeMaisItensParaAdicionar(event)">+ Mais Itens</button>
                </div>
              </div>
          </div>
            <div class="linha total">
              <div id="caixa total">
                <h2 id="caixa_total__soma"> Total: R$ 0,00 </h2>
              </div>
              <div id="caixa_botaosalvar">
                <button class="botaosalvar" id='botaosalvar' onclick="checarOpcaoSalvarOuAtualizar()"> Salvar</button>
                <div id="alerta"></div>
              </div>
            </div>
        </form>
      </div>
</template>

<script>
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'CadastroVendas'
})
</script>
