import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { IProduto } from '../produto.model';
import { ProdutoService } from '../produto.service';

@Component({
  selector: 'app-cadastro-produto',
  templateUrl: './cadastro-produto.component.html',
  styleUrls: ['./cadastro-produto.component.css']
})
export class CadastroProdutoComponent implements OnInit {

  public form!: FormGroup;

  constructor(private produtoService: ProdutoService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      descricao: new FormControl(null, [Validators.minLength(3), Validators.required]),
      valor: new FormControl(null, [Validators.min(0.01), Validators.required]),
      validade: new FormControl(null, [Validators.required])
    });
  }

  public salvarProduto(): void {
    if (this.form.valid) {
      const novoProduto: IProduto = {
        id: this.form.value.id,
        descricao: this.form.value.descricao,
        valor: this.form.value.valor,
        quantidade: 0,
        validade: this.form.value.validade,
        ativo: true,
      }
      this.produtoService.salvarProduto(novoProduto).pipe(take(1)).subscribe(
        () => { 
          alert('Produto salvo com sucesso!')
          this.form.reset();
        } );      
    }
  }
}
