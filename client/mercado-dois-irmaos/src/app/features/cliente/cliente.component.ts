import { Component, Input, OnInit } from '@angular/core';
import { ICliente } from './cliente.model';
import { ClienteService } from './cliente.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {


  constructor(private clienteService: ClienteService) { }

  ngOnInit(): void {
  }

}
