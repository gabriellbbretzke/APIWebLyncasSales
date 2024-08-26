<template>
    <div class="barralateral">
        <div>
            <img id="imagemlyncas" src="https://lyncas.net/wp-content/uploads/2021/11/Logo-Transparente-Branca.png"
                alt="Lyncas" />
        </div>
        <div class="barralateral-botoes">
            <RouterLink to="/" class="routerLink_barralateral">
                <button class="botoes_barralateral">
                    <i class="fa-solid fa-gauge-simple"></i> Dashboard
                </button>
            </RouterLink>
            <RouterLink to="/listadeclientes" class="routerLink_barralateral">
                <button class="botoes_barralateral">
                    <i class="fa-solid fa-users-rays"></i> Clientes
                </button>
            </RouterLink>
            <router-link to="/listadevendas" class="routerLink_barralateral">
                <button class="botoes_barralateral">
                    <i class="fa-brands fa-sellcast"></i> Vendas
                </button>
            </router-link>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'BarraLateral'
})
</script>
