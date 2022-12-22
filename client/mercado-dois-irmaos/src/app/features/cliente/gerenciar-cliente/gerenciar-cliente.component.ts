import { Component, OnInit, TemplateRef } from '@angular/core';
import { take } from 'rxjs';
import { ClienteService } from '../cliente.service';
import { ICliente } from '../cliente.model';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-gerenciar-cliente',
  templateUrl: './gerenciar-cliente.component.html',
  styleUrls: ['./gerenciar-cliente.component.css'],
})

export class GerenciarClienteComponent implements OnInit {

  modalRef!: BsModalRef;
  cpfSelecionado?: number;
  clienteBuscado?: ICliente;

  listaClientes?: ICliente[] = [];
  
  constructor(private clienteService: ClienteService, 
              private modalService: BsModalService) { }

  ngOnInit(): void {
    this.buscarClientes();
  }

  buscarClientes() {
    this.clienteService.buscarClientes()
    .subscribe((dados) => {
      if(dados){
        this.listaClientes = dados;
      }
    });
  }
  buscarCliente(cpf: number) {
    this.clienteService.buscarCliente(cpf)
    .subscribe((dados) => {
      if(dados){
        this.clienteBuscado = dados;
      }
    });
  }

  excluirCliente(template: TemplateRef<any>, cpf: number) {
    this.cpfSelecionado = cpf;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});

  }
 
  confirmar(): void {
    this.clienteService.excluirCliente(this.cpfSelecionado)
    .pipe(take(1))
    .subscribe(
      () => {
        this.buscarClientes();
      });
    this.modalRef?.hide();
  }
 
  rejeitar(): void {
    this.modalRef?.hide();
  }

}
