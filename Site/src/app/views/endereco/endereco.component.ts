import { Component, Input, ViewChild, OnChanges, SimpleChanges } from '@angular/core';
import { ModalEnderecoComponent } from '../../shared/modal-endereco/modal-endereco.component';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { enderecoModel } from '../../models/enderecoModel';
import { EnderecoService } from '../../services/endereco.service';


@Component({
  selector: 'app-endereco',
  templateUrl: './endereco.component.html',
  styleUrl: './endereco.component.scss',
  providers: [EnderecoService]
})
export class EnderecoComponent implements OnChanges {
  @ViewChild(MatTable) 
  tabela!: MatTable<any>;
  displayedColumns: string[] = ['id', 'comercial', 'cep', 'logradouro', 'numero', 'bairro', 'cidade', 'uf', 'complemento',  'dataDeCadastro', 'dataDeAlteracao', 'acoes'];
  listaDeEnderecos!:enderecoModel[];
  
  @Input() clienteId!: number;
  
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['clienteId']) {
      this.carregarTodos();
    }
  }


  constructor(
    public dialog: MatDialog,
    public enderecoService: EnderecoService
    ) { }

  abrirModal(endereco: enderecoModel | null) : void {
    
    const dialogRef = this.dialog.open(ModalEnderecoComponent, {
      data: endereco === null ? {
        id: 0,
        clienteId: this.clienteId, 
        cep: '',
        logradouro: '',
        numero: '',
        complemento: '',
        bairro: '',
        cidade: '',
        uf: '',
        comercial: '',
      } : 
      {
        id: endereco.id,
        clienteId: endereco.clienteId, 
        cep: endereco.cep,
        logradouro: endereco.logradouro,
        numero: endereco.numero,
        complemento: endereco.complemento,
        bairro: endereco.bairro,
        cidade: endereco.cidade,
        uf: endereco.uf,
        comercial: endereco.comercial,
      }
    });
  
    dialogRef.afterClosed().subscribe(result => {
      this.carregarTodos();
    });
  }

  removerElemento(id: number):void{
    this.enderecoService.apagar(id).subscribe((data: enderecoModel[]) => {
      this.carregarTodos();
    });
  }

  editarElemento(cliente: enderecoModel):void{
    this.abrirModal(cliente);
  }

  carregarTodos(): void{
    this.enderecoService.recuperarTodos(this.clienteId).subscribe((data: enderecoModel[]) => {
      this.listaDeEnderecos = data;
    });

  }
}
