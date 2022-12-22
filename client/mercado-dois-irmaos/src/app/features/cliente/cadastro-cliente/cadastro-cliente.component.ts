import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { ICliente } from '../cliente.model';
import { ClienteService } from '../cliente.service';

@Component({
  selector: 'app-cadastro-cliente',
  templateUrl: './cadastro-cliente.component.html',
  styleUrls: ['./cadastro-cliente.component.css']
})
export class CadastroClienteComponent implements OnInit {

  public form!: FormGroup;
  
  constructor(private clienteService: ClienteService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      cpf: new FormControl(null, [Validators.required, Validators.minLength(11), Validators.maxLength(11)]),
      nome: new FormControl('', [Validators.required, Validators.minLength(3)]),
      dataNascimento: new FormControl(null, [Validators.required]),
    });
  }

  public salvarCliente(): void {
    if (this.form.valid) {
      const novoCliente: ICliente = {
        cpf: this.form.value.cpf,
        nome: this.form.value.nome,
        dataNascimento: this.form.value.dataNascimento,
        ptsFidelidade: 0
      }
      this.clienteService.salvarCliente(novoCliente).pipe(take(1)).subscribe(
        () => { 
          alert('Cliente salvo com sucesso!')
          this.form.reset();
        });
    }
  }
}
