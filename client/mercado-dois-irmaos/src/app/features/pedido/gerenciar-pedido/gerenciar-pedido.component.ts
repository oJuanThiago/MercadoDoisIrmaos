import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { take } from 'rxjs';
import { IPedido } from '../pedido.model';
import { PedidoService } from '../pedido.service';

@Component({
  selector: 'app-gerenciar-pedido',
  templateUrl: './gerenciar-pedido.component.html',
  styleUrls: ['./gerenciar-pedido.component.css']
})
export class GerenciarPedidoComponent implements OnInit {
  
  modalRef!: BsModalRef;
  listaPedidos?: IPedido[] = [];
  idSelecionado?: number;

  constructor(private pedidoService: PedidoService,
              private modalService: BsModalService) { }

  ngOnInit(): void {
    this.buscarPedidos();
  }
  
  buscarPedidos() {
    this.pedidoService.buscarPedidos()
    .subscribe((dados) => {
      if(dados){
        this.listaPedidos = dados;
      }
    });
  }
  excluirPedido(template: TemplateRef<any>, id: number) {
    this.idSelecionado = id;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});

  }
 
  confirmar(): void {
    this.pedidoService.excluirPedido(this.idSelecionado)
    .pipe(take(1))
    .subscribe(
      () => {
        this.buscarPedidos();
      });
    this.modalRef?.hide();
  }
 
  rejeitar(): void {
    this.modalRef?.hide();
  }


}
