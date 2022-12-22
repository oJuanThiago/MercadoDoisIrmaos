import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { IProduto } from '../produto.model';
import { ProdutoService } from '../produto.service';

@Component({
  selector: 'app-gerenciar-produto',
  templateUrl: './gerenciar-produto.component.html',
  styleUrls: ['./gerenciar-produto.component.css']
})
export class GerenciarProdutoComponent implements OnInit {

  listaProdutos?: IProduto[] = [];

  constructor(private produtoService: ProdutoService) { }

  ngOnInit(): void {
    this.buscarProdutos();
  }

  public buscarProdutos() {
    this.produtoService.buscarProdutos()
    .subscribe((dados) => {
      if(dados){
        this.listaProdutos = dados;
      }
    });
  }
  public ativarDesativarProduto(produto: IProduto) {
    this.produtoService.ativarDesativarProduto(produto)
    .pipe(take(1)).subscribe(
      () => {
      });
    this.buscarProdutos();
  }

}
