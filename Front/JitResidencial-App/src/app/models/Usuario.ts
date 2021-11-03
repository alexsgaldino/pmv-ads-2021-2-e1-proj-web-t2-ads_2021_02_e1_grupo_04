import { Endereco } from "./Endereco";
import { Grupo } from "./Grupo";
import { Produto } from "./Produto";

export interface Usuario {
  id: number;
  primeiroNome: string;
  sobrenome: string;
  telefone: string;
  email: string;
  senha: string;
  dataInclusao: Date;
  ultimaAtualizacao: Date;
  grupoId: number;
  enderecoId: number;
  produtoId: number;
}
