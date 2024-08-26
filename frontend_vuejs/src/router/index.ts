import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import IndexView from '../views/IndexView.vue'
import ListaClientes from '../views/ListaClientesView.vue'
import ListaVendas from '../views/ListaVendasView.vue'
import CadastroClientes from '../views/CadastroClientesView.vue'
import CadastroVendas from '../views/CadastroVendaView.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'Dashboard',
    component: IndexView
  },
  {
    path: '/listadeclientes',
    name: 'Lista de Clientes',
    component: ListaClientes
  },
  {
    path: '/listadevendas',
    name: 'Lista de Vendas',
    component: ListaVendas
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    // component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  {
    path: '/cadastroClientes',
    name: 'Cadastro de Clientes',
    component: CadastroClientes
  },
  {
    path: '/cadastroVendas',
    name: 'Cadastro de Vendas',
    component: CadastroVendas
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
