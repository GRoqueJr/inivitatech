import { enderecoModel } from "./enderecoModel";

export interface clienteModel {
    id: number;
    nome: string;
    dataDeNascimento: Date;
    tipoDeClienteSexo: number;
    dataDeCadastro: Date;
    dataDeAlteracao: Date | null;
    enderecos: enderecoModel[];
  }