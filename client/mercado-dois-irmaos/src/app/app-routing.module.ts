import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroClienteComponent } from './features/cliente/cadastro-cliente/cadastro-cliente.component';
import { CadastroProdutoComponent } from './features/produto/cadastro-produto/cadastro-produto.component';
import { CadastroPedidoComponent } from './features/pedido/cadastro-pedido/cadastro-pedido.component';
import { GerenciarClienteComponent } from './features/cliente/gerenciar-cliente/gerenciar-cliente.component';
import { EditarClienteComponent } from './features/cliente/editar-cliente/editar-cliente.component';
import { GerenciarProdutoComponent } from './features/produto/gerenciar-produto/gerenciar-produto.component';
import { GerenciarPedidoComponent } from './features/pedido/gerenciar-pedido/gerenciar-pedido.component';
import { EditarProdutoComponent } from './features/produto/editar-produto/editar-produto.component';
import { EstoqueProdutoComponent } from './features/produto/estoque-produto/estoque-produto.component';
import { EditarPedidoComponent } from './features/pedido/editar-pedido/editar-pedido.component';

const routes: Routes = [
  {
    path: 'cliente',
    children: [
      {
        path: 'cadastro',
        component: CadastroClienteComponent,
      },
      {
        path: 'lista',
        component: GerenciarClienteComponent,
      },
      {
        path: 'editar/:cpf',
        component: EditarClienteComponent,
      }
    ]
  },
  {
    path: 'produto',
    children: [
      {
        path: 'cadastro',
        component: CadastroProdutoComponent,
      },
      {
        path: 'lista',
        component: GerenciarProdutoComponent,
      },
      {
        path: 'editar/:id',
        component: EditarProdutoComponent,
      },
      {
        path: 'estoque/:id',
        component: EstoqueProdutoComponent,
      },
    ]
  },
  {
    path: 'pedido',
    children: [
      {
        path: 'cadastro',
        component: CadastroPedidoComponent,
      },
      {
        path: 'lista',
        component: GerenciarPedidoComponent,
      },
      {
        path: 'editar/:id',
        component: EditarPedidoComponent,
      },
    ]
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
