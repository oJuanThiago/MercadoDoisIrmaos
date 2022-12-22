import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastroClienteComponent } from './features/cliente/cadastro-cliente/cadastro-cliente.component';
import { GerenciarClienteComponent } from './features/cliente/gerenciar-cliente/gerenciar-cliente.component';
import { EditarClienteComponent } from './features/cliente/editar-cliente/editar-cliente.component';
import { CadastroPedidoComponent } from './features/pedido/cadastro-pedido/cadastro-pedido.component';
import { CadastroProdutoComponent } from './features/produto/cadastro-produto/cadastro-produto.component';
import { ClienteService } from './features/cliente/cliente.service';
import { ProdutoService } from './features/produto/produto.service';
import { ProdutoComponent } from './features/produto/produto.component';
import { ClienteComponent } from './features/cliente/cliente.component';
import { PedidoComponent } from './features/pedido/pedido.component';
import { PedidoService } from './features/pedido/pedido.service';
import { GerenciarProdutoComponent } from './features/produto/gerenciar-produto/gerenciar-produto.component';
import { EditarProdutoComponent } from './features/produto/editar-produto/editar-produto.component';
import { EstoqueProdutoComponent } from './features/produto/estoque-produto/estoque-produto.component';
import { GerenciarPedidoComponent } from './features/pedido/gerenciar-pedido/gerenciar-pedido.component';
import { EditarPedidoComponent } from './features/pedido/editar-pedido/editar-pedido.component';
import { StatusPedidoComponent } from './features/pedido/status-pedido/status-pedido.component';

@NgModule({
  declarations: [
    AppComponent,
    CadastroClienteComponent,
    GerenciarClienteComponent,
    EditarClienteComponent,
    CadastroPedidoComponent,
    CadastroProdutoComponent,
    ProdutoComponent,
    ClienteComponent,
    PedidoComponent,
    GerenciarProdutoComponent,
    EditarProdutoComponent,
    EstoqueProdutoComponent,
    GerenciarPedidoComponent,
    EditarPedidoComponent,
    StatusPedidoComponent
  ],
  imports: [
    ModalModule.forRoot(),
    TooltipModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [ClienteService, ProdutoService, PedidoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
