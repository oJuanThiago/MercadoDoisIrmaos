import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IProduto } from "./produto.model";

@Injectable({
    providedIn: 'root'
})
export class ProdutoService {
    private api: string = 'https://localhost:5001/produto';

    constructor(private httpClient: HttpClient) { }

    public salvarProduto(novoProduto: IProduto): Observable<boolean> {
        return this.httpClient.post<boolean>(`${this.api}`, novoProduto);
    }

    public buscarProdutos(): Observable<IProduto[]> {
        return this.httpClient.get<IProduto[]>(`${this.api}/todos`)
    }

    public buscarProduto(id: number): Observable<IProduto> {
        return this.httpClient.get<IProduto>(`${this.api}/` + id)
    }

    public atualizarProduto(produto: IProduto): Observable<boolean> {
        return this.httpClient.put<boolean>(`${this.api}`, produto);
    }

    public ativarDesativarProduto(produto: IProduto): Observable<IProduto> {
        return this.httpClient.put<IProduto>(`${this.api}`, produto);
    }

}