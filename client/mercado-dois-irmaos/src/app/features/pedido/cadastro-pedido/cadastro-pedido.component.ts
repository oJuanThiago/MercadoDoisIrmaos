import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { IProduto } from '../../produto/produto.model';
import { ProdutoService } from '../../produto/produto.service';
import { IPedido } from '../pedido.model';
import { PedidoService } from '../pedido.service';

@Component({
  selector: 'app-cadastro-pedido',
  templateUrl: './cadastro-pedido.component.html',
  styleUrls: ['./cadastro-pedido.component.css']
})
export class CadastroPedidoComponent implements OnInit {

  public form!: FormGroup;
  public listaProdutos?: IProduto[] = [];

  constructor(private pedidoService: PedidoService,
              private produtoService: ProdutoService) { }

  ngOnInit(): void {
    this.buscarProdutos();
    this.form = new FormGroup({
      cpf: new FormControl(null),
      produto: new FormControl(null),
      quantidade: new FormControl(null, [Validators.required]),
    });

  }
  buscarProdutos() {
    this.produtoService.buscarProdutos()
    .subscribe((dados) => {
      if(dados){
        this.listaProdutos = dados;
      }
    });
  }
  salvarPedido() {
    if (this.form.valid) {
      const novoCliente: IPedido = {
        id: this.form.value.id,
        cliente: this.form.value.cliente,
        produto: this.form.value.produto,
        quantidade: this.form.value.quantidade,
        dataHora: this.form.value.dataHora,
        status: this.form.value.status,
        valorTotal: this.form.value.valorTotal
      }
      this.pedidoService.salvarPedido(novoCliente).pipe(take(1)).subscribe(
        () => { 
          alert('Pedido realizado com sucesso!')
          this.form.reset();
        });
    }
  }

}
