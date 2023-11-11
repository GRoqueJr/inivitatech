import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { enderecoModel } from '../../models/enderecoModel';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EnderecoService } from '../../services/endereco.service';
import { viaCepModel } from '../../models/viaCepModel';

@Component({
  selector: 'app-modal-endereco',
  templateUrl: './modal-endereco.component.html',
  styleUrl: './modal-endereco.component.scss',
  providers: [EnderecoService]
})

  export class ModalEnderecoComponent implements OnInit {
    cliente!: enderecoModel;
    emEdicao!:boolean;
    formulario!: FormGroup;

    constructor(
      private formBuilder: FormBuilder,
      public enderecoService: EnderecoService,
      @Inject(MAT_DIALOG_DATA) public data: enderecoModel,
      public dialogRef: MatDialogRef<ModalEnderecoComponent>,
    ) {}
  
    ngOnInit() : void {

      this.formulario = this.formBuilder.group({
        id: this.data.id,
        clienteId: [this.data.clienteId, Validators.required],
        cep: ['', [Validators.required, Validators.minLength(8)]],
        logradouro: [{value:'',disabled: true}, Validators.required],
        numero: [{value:'',disabled: true}, Validators.required],
        complemento: {value:'',disabled: true},
        bairro: {value:'', disabled: true},
        cidade: [{value:'', disabled: true}, Validators.required],
        uf: [{value:'', disabled: true}, Validators.required],
        comercial: {value:false, disabled: true},
      });

      this.inicializarFormulario();
      this.emEdicao = this.data.id > 0;


    }
  
    inicializarFormulario(): void {

    
        if(this.data.id > 0) {
    
          this.enderecoService.recuperar(this.data.id).subscribe((endereco: enderecoModel) => {
     
            this.formulario.get('id')!.patchValue(endereco.id);
            this.formulario.get('clienteId')!.patchValue(endereco.id);
            this.formulario.get('cep')!.patchValue(endereco.cep);
            this.formulario.get('logradouro')!.patchValue(endereco.logradouro);
            this.formulario.get('numero')!.patchValue(endereco.numero);
            this.formulario.get('complemento')!.patchValue(endereco.complemento);
            this.formulario.get('bairro')!.patchValue(endereco.bairro);
            this.formulario.get('cidade')!.patchValue(endereco.cidade);
            this.formulario.get('uf')!.patchValue(endereco.uf);
            this.formulario.get('comercial')!.patchValue(endereco.comercial);
            
          });
        }

        // Monitorar mudanças no campo "cep"

        this.formulario.get('cep')!.valueChanges.subscribe((value: string) => {
        if (value.length === 8) {
          this.enderecoService.recuperarViaCep(value).subscribe((result: viaCepModel) => {
            
           if(result.logradouro === undefined ) {

            this.formulario.get('cep')!.patchValue('');
            this.formulario.get('logradouro')!.patchValue('');
            this.formulario.get('numero')!.patchValue('');
            this.formulario.get('complemento')!.patchValue('');
            this.formulario.get('bairro')!.patchValue('');
            this.formulario.get('cidade')!.patchValue('');
            this.formulario.get('uf')!.patchValue('');
            this.formulario.get('comercial')!.patchValue('');


            this.lilberarFormularioCompleto();
            return;
           }
            result.logradouro == "" ?  this.formulario.get('logradouro')!.enable() : this.formulario.get('logradouro')!.disable();
            result.bairro == "" ?  this.formulario.get('bairro')!.enable() : this.formulario.get('bairro')!.disable();
            result.localidade == "" ?  this.formulario.get('cidade')!.enable() : this.formulario.get('cidade')!.disable();
            result.uf == "" ?  this.formulario.get('uf')!.enable() : this.formulario.get('uf')!.disable();

            this.formulario.get('logradouro')!.patchValue(`${result.logradouro} ${result.complemento}`);
            this.formulario.get('bairro')!.patchValue(result.bairro);
            this.formulario.get('cidade')!.patchValue(result.localidade);
            this.formulario.get('uf')!.patchValue(result.uf);

          
            this.formulario.get('numero')!.enable();
            this.formulario.get('complemento')!.enable();
            this.formulario.get('comercial')!.enable();


          });
        }
        
      });

    }
  
    submitForm(): void {
      
      if (this.formulario.valid) {
       
        this.lilberarFormularioCompleto();
        
        const dadosFormulario = this.formulario.value;
        
        this.enderecoService.cadastrar(dadosFormulario).subscribe((data: enderecoModel) => {
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

    private lilberarFormularioCompleto(): void {
      this.formulario.get('logradouro')!.enable();
      this.formulario.get('bairro')!.enable();
      this.formulario.get('cidade')!.enable();
      this.formulario.get('uf')!.enable();
      this.formulario.get('numero')!.enable();
      this.formulario.get('complemento')!.enable();
      this.formulario.get('comercial')!.enable();
    }
  }
  
