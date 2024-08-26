<template>
  <BarraLateral />
  <nav>
    <!------ MAIN ------>
    <section id="principal">
      <Cabecalho />
      <!------ CONTEUDO ------>
      <router-view/>
    </section>
  </nav>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Cabecalho from './views/CabecalhoView.vue'
import BarraLateral from './views/BarraLateralView.vue'

export default defineComponent({
  components: {
    Cabecalho,
    BarraLateral
  }
})
</script>

<style>
/*------ BEM VINDO TELA PRINCIPAL ------*/
.principal-titulo-bemvindo {
    width: 100%;
    padding-top: 200px;
    text-align: center;
    color: #26334B;
    font-size: 26px;
}
</style>
