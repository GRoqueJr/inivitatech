import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError  } from 'rxjs';
import { enderecoModel } from '../models/enderecoModel';
import { catchError, map } from 'rxjs/operators';
import { viaCepModel } from '../models/viaCepModel';


@Injectable()
export class EnderecoService {
    apiUrl = "https://localhost:7230/api/clientesenderecos";
    clienteId: number = 0;
    constructor(private http: HttpClient){}

    recuperar(id: number): Observable<enderecoModel> {
        return this.http.get<enderecoModel>(`${this.apiUrl}/recuperar/${id}`);
    }

    recuperarTodos(clienteId: number): Observable<enderecoModel[]> {
        return this.http.get<enderecoModel[]>(`${this.apiUrl}/todos/${clienteId}`);
    }

    cadastrar(endereco: enderecoModel): Observable<enderecoModel> {
        return this.http.post<enderecoModel>(`${this.apiUrl}/cadastrar`, endereco).pipe(
            catchError(this.handleError)
          );
    }

    apagar(id: number): Observable<any> {
        return this.http.delete<any>(`${this.apiUrl}/excluir/${id}`);
    }

    private handleError(error: any) {
        // Aqui você pode tratar o erro como preferir
        console.error('>>>>>>>>>>>>>>>>>>>>:', error);
    
        // Você pode reformatar o erro ou lançar novamente para que o componente possa tratá-lo
        return throwError('AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA');
      }


      /* Via Cep */
      recuperarViaCep(cep: string): Observable<viaCepModel> {

        return this.http.get(`https://viacep.com.br/ws/${cep}/json/`).pipe(
            map((response: any) => {
              // Verifica se a resposta contém um vetor de dados (indicativo de sucesso)
              if (Array.isArray(response)) {
                return response[0]; // Retorna o primeiro item do vetor
              } else {
                return response; // Retorna o objeto normalmente
              }
            }),
            catchError(error => this.handleError(error))
          );
    }
}