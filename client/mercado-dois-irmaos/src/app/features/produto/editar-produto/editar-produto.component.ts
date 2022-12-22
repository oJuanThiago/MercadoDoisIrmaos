import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { IProduto } from '../produto.model';
import { ProdutoService } from '../produto.service';

@Component({
  selector: 'app-editar-produto',
  templateUrl: './editar-produto.component.html',
  styleUrls: ['./editar-produto.component.css']
})
export class EditarProdutoComponent implements OnInit {
  public form!: FormGroup;
  produtoBuscado?: IProduto;

  constructor(private produtoService: ProdutoService,
              private route:ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.form = new FormGroup({
      descricao: new FormControl(null, [Validators.minLength(3), Validators.required]),
      valor: new FormControl(null, [Validators.min(0.001), Validators.required]),
      validade: new FormControl(null, [Validators.required])
    });
    this.buscarProduto(Number(id))
  }
  buscarProduto(id: number) {
    this.produtoService.buscarProduto(id).subscribe((dados) => {
      if(dados){
        this.produtoBuscado = dados;
        this.form.get('descricao')?.setValue(this.produtoBuscado.descricao);
        this.form.get('valor')?.setValue(this.produtoBuscado.valor);
        this.form.get('validade')?.setValue(this.produtoBuscado.validade);
      }
    });
  }

  public atualizarProduto(): void {
    if (this.form.valid) {
      const produto: IProduto = {
        id: this.form.value.id,
        descricao: this.form.value.descricao,
        valor: this.form.value.valor,
        quantidade: this.form.value.quantidade,
        validade: this.form.value.validade,
        ativo: this.form.value.ativo
      }
      this.produtoService.atualizarProduto(produto).pipe(take(1)).subscribe(
        () => { 
          if (produto.validade.getDate() > Number(Date.now)) {
            alert('Produto salvo com sucesso!')
          }
        });
        this.form.reset();          
    }
  }

}
