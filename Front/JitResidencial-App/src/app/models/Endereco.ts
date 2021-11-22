import { Produto } from "./Produtct";

export interface Endereco {
  id: number;
  CEP: string;
  rua: string;
  numero: string;
  dataCadastro?: Date;
  bairro: string;
  cidade: string;
  UF: string;
  dataInclusao?: Date;
  dataAtualizacao?: Date;
  produtoId: number;
}
