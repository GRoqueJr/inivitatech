
export interface enderecoModel {
    id: number;
    clienteId: number;
    cep: string;
    logradouro : string;
    numero: string;
    complemento: string | null;
    bairro: string | null;
    cidade: string;
    uf: string;
    comercial: boolean ;
    dataDeCadastro: Date;
    dataDeAlteracao: Date | null;
  }