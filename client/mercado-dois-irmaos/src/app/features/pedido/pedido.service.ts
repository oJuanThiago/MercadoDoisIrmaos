import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IPedido } from "./pedido.model";

@Injectable({
    providedIn: 'root'
})

export class PedidoService {
    private api: string = 'https://localhost:5001/pedido';
    
    constructor(private httpClient: HttpClient) { }

    public salvarPedido(novoPedido: IPedido): Observable<boolean> {
        return this.httpClient.post<boolean>(`${this.api}`, novoPedido);
    }

    public buscarPedidos(): Observable<IPedido[]> {
        return this.httpClient.get<IPedido[]>(`${this.api}/todos`)
    }

    public buscarPedido(id: number): Observable<IPedido> {
        return this.httpClient.get<IPedido>(`${this.api}/` + id)
    }

    public atualizarPedido(pedido: IPedido): Observable<boolean> {
        return this.httpClient.put<boolean>(`${this.api}`, pedido);
    }

    public excluirPedido(id?: number): Observable<boolean> {
        return this.httpClient.delete<boolean>(`${this.api}/`+ id);
    }

}