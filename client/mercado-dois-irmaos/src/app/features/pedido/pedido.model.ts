import { ICliente } from "../cliente/cliente.model";
import { IProduto } from "../produto/produto.model";

export interface IPedido {
    id: number;
    cliente: ICliente;
    produto: IProduto;
    dataHora: Date;
    quantidade: number;
    status: number;
    valorTotal: number;
}