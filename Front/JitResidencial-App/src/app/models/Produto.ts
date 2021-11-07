
export interface Produto {

 id: number;
 codigoBarras:  string;
 nomeProduto:  string;
 quantidade:  number;
 volume:  string;
 dataValidade:  string;
 dataInclusao?:  Date;
 dataAlteracao?:  Date;
 unidadeMedidaId: number;
 categoriaId: number;
 movimentoId: number;
 estoqueId: number;
 listaPrecoId:  number;
 fornecedorId: number;
}