import { Component, OnInit } from '@angular/core';
import { PedidoService } from '../pedido.service';

@Component({
  selector: 'app-status-pedido',
  templateUrl: './status-pedido.component.html',
  styleUrls: ['./status-pedido.component.css']
})
export class StatusPedidoComponent implements OnInit {

  constructor(private pedidoService: PedidoService) { }

  ngOnInit(): void {
  }

}
