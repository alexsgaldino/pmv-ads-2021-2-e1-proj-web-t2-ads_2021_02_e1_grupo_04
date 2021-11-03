export interface Fornecedor {
  id: number;
  CNPJ: string;
  nome: string;
  nomeFantasia: string;
  dataInclusao?: Date;
}
