export interface IProduto {
    id: number;
    descricao: string;
    valor: number;
    quantidade: number;
    validade: Date;
    ativo: boolean;
}