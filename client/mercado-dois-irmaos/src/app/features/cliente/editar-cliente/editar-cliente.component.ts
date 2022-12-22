import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { ICliente } from '../cliente.model';
import { ClienteService } from '../cliente.service';

@Component({
  selector: 'app-editar-cliente',
  templateUrl: './editar-cliente.component.html',
  styleUrls: ['./editar-cliente.component.css']
})
export class EditarClienteComponent implements OnInit {

  public form!: FormGroup;
  clienteBuscado?: ICliente;

  constructor(private clienteService: ClienteService,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    const cpf = this.route.snapshot.paramMap.get('cpf');
    this.form = new FormGroup({
      cpf: new FormControl(null, [Validators.required, Validators.minLength(11)]),
      nome: new FormControl('', [Validators.required, Validators.minLength(3)]),
      dataNascimento: new FormControl(null, [Validators.required]),
    });
    this.buscarCliente(Number(cpf));
  }

  buscarCliente(cpf: number) {
    this.clienteService.buscarCliente(cpf)
    .subscribe((dados) => {
      if(dados){
        this.clienteBuscado = dados;
        this.form.get('cpf')?.setValue(this.clienteBuscado.cpf);
        this.form.get('nome')?.setValue(this.clienteBuscado.nome);
        this.form.get('dataNascimento')?.setValue(this.clienteBuscado.dataNascimento);
      }
    });
  }

  
  public atualizarCliente(): void {
    if (this.form.valid) {
      const cliente: ICliente = {
        cpf: this.form.value.cpf,
        nome: this.form.value.nome,
        dataNascimento: this.form.value.dataNascimento,
        ptsFidelidade: this.form.value.ptsFidelidade
      }
      this.clienteService.atualizarCliente(cliente)
      .pipe(take(1)).subscribe(
        () => { 
          alert('Cliente atualizado com sucesso!')
        });
    }
  }
}
