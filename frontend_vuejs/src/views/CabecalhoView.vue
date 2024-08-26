<template>
    <div id="usuario">
        <div id="perfil">
            <img id="imagemusuario" src="https://cdn-icons-png.flaticon.com/512/16/16467.png" />
            <span class="principal-saudacao">Olá Genara</span>
            <div id="texto_sair_usuario">
                Sair
            </div>
        </div>
        <BotaoVoltar />
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import BotaoVoltar from './BotaoVoltar.vue'

export default defineComponent({
  // eslint-disable-next-line vue/multi-word-component-names
  name: 'Cabecalho',
  components: {
    BotaoVoltar
  }
})
</script>
