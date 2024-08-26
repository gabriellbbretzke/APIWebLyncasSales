import { createApp } from 'vue'
// import VueMask from 'v-mask'
import App from './App.vue'
import router from './router'
import store from './store'
import './assets/css/estilo.css'
import './assets/css/listadeclientes.css'
import './assets/css/listadevendas.css'
import './assets/css/cadastrodevendas.css'
import './assets/css/cadastrodeclientes.css'

// import { library } from "@fortawesome/fontawesome-svg-core"
// import { faPhone } from "@fortawesome/free-solid-svg-icons"
// import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome"

const app = createApp(App)
// library.add(faPhone)

app.use(store)
app.use(router)
app.mount('#app')
// app.component("font-awesome-icon", FontAwesomeIcon)
