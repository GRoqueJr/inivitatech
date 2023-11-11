import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { clienteModel } from '../../models/clienteModel';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClienteService } from '../../services/cliente.service';


@Component({
  selector: 'app-modal-cliente',
  templateUrl: './modal-cliente.component.html',
  styleUrl: './modal-cliente.component.scss',
  providers: [ClienteService]
})
export class ModalClienteComponent implements OnInit {
  cliente!: clienteModel;
  emEdicao!:boolean;
  formulario!: FormGroup;
  
  constructor(
    private formBuilder: FormBuilder,
    public clienteService: ClienteService,
    @Inject(MAT_DIALOG_DATA) public data: clienteModel,
    public dialogRef: MatDialogRef<ModalClienteComponent>,
  ) {}

  ngOnInit() : void {
    this.inicializarFormulario();
    this.emEdicao = this.data.id != null;
  }

  inicializarFormulario(): void {

    this.formulario = this.formBuilder.group({
      id: 0,
      nome: ['', Validators.required],
      dataDeNascimento: [null, Validators.required],
      tipoDeClienteSexo: [1, Validators.required],
    });

    if(this.data.id > 0) {

      this.clienteService.recuperar(this.data.id).subscribe((cliente: clienteModel) => {
        this.formulario = this.formBuilder.group({
          id: cliente.id,
          nome: [cliente.nome, Validators.required],
          dataDeNascimento: [cliente.dataDeNascimento, Validators.required],
          tipoDeClienteSexo: [cliente.tipoDeClienteSexo, Validators.required],
        });
        
      });
    }


  
  }

  submitForm(): void {
    
    if (this.formulario.valid) {
      const dadosFormulario = this.formulario.value;

      this.clienteService.cadastrar(dadosFormulario).subscribe((data: clienteModel) => {
        this.dialogRef.close();
      });
      // Faça algo com os dados do formulário, como enviar para o servidor
      console.log('Dados do formulário:', dadosFormulario);
    } else {
      // Exiba mensagens de erro ou realize outras ações necessárias
      console.log('Formulário inválido. Verifique os campos obrigatórios.');
    }
  }

  aoCancelar(): void {
    this.dialogRef.close();
    return;
  }
  
}
