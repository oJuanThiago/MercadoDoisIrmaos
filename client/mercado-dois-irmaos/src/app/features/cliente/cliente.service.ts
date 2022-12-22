import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ICliente } from "./cliente.model";

@Injectable({
    providedIn: 'root'
})
export class ClienteService {
    private api: string = 'https://localhost:5001/cliente';
    
    constructor(private httpClient: HttpClient) { }

    public salvarCliente(novoCliente: ICliente): Observable<boolean> {
        return this.httpClient.post<boolean>(`${this.api}`, novoCliente);
    }

    public buscarClientes(): Observable<ICliente[]> {
        return this.httpClient.get<ICliente[]>(`${this.api}/todos`)
    }

    public buscarCliente(cpf: number): Observable<ICliente> {
        return this.httpClient.get<ICliente>(`${this.api}/` + cpf)
    }

    public atualizarCliente(cliente: ICliente): Observable<boolean> {
        return this.httpClient.put<boolean>(`${this.api}`, cliente);
    }

    public excluirCliente(cpf?: number): Observable<boolean> {
        return this.httpClient.delete<boolean>(`${this.api}/`+ cpf);
    }
  
}