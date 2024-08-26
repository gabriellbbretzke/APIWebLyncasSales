<template>
    <div class="principal-caixa_botaovoltar">
        <button class="principal-botaovoltar" @click="botaoVoltar()"> Voltar </button>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'BotaoVoltar',
  methods: {
    botaoVoltar () {
      window.history.back()
    }
  }
})

</script>
