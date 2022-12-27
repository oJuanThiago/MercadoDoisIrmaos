export interface IPedido {
    id: number;
    cpfCliente: number;
    idProduto: number;
    dataHora: Date;
    quantidade: number;
    status: number;
    valorTotal: number;
}