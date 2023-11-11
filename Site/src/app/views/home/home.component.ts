import { Component, ViewChild } from '@angular/core';
import { ModalClienteComponent } from '../../shared/modal-cliente/modal-cliente.component';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { clienteModel } from '../../models/clienteModel';
import { ClienteService } from '../../services/cliente.service';
import { EnderecoService } from '../../services/endereco.service';
import {animate, state, style, transition, trigger} from '@angular/animations';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
  providers: [ClienteService, EnderecoService],
  animations: [
    trigger('detailExpand', [
      state('collapsed,void', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})


export class HomeComponent  {
  @ViewChild(MatTable) 
  tabela!: MatTable<any>;
  displayedColumns: string[] = ['id', 'nome', 'dataDeNascimento', 'tipoDeClienteSexo', 'dataDeCadastro', 'dataDeAlteracao', 'acoes'];
  listaDeClientes!:clienteModel[];
  columnsToDisplayWithExpand = [...this.displayedColumns, 'expand'];
  expandedElement: clienteModel | null | undefined;

  
  constructor(
    public dialog: MatDialog,
    public enderecoService: EnderecoService,
    public clienteService: ClienteService
    ) {

      this.carregarTodos();

    }

  abrirModal(cliente: clienteModel | null) : void {
    
    const dialogRef = this.dialog.open(ModalClienteComponent, {
      data: cliente === null ? {id: null, nome: '', dataDeNascimento: null, tipoDeClienteSexo: ''} : 
      {id: cliente.id, nome: cliente.nome, dataDeNascimento: cliente.dataDeNascimento, tipoDeClienteSexo: cliente.tipoDeClienteSexo}
    });
  
    dialogRef.afterClosed().subscribe(result => {
      this.clienteService.recuperarTodos().subscribe((data: clienteModel[]) => {
        this.listaDeClientes = data;
      });
    });
  }

  removerElemento(id: number):void{
    this.clienteService.apagar(id).subscribe((data: clienteModel[]) => {
      this.carregarTodos();
    });
  }

  editarElemento(cliente: clienteModel):void{
    this.abrirModal(cliente);
  }

  carregarTodos(): void{
    this.clienteService.recuperarTodos().subscribe((data: clienteModel[]) => {
      this.listaDeClientes = data;
    });

  }

  carregarEnderecos(): void {

  }


}
