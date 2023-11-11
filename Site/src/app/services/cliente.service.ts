import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError  } from 'rxjs';
import { clienteModel } from '../models/clienteModel';
import { catchError } from 'rxjs/operators';


@Injectable()
export class ClienteService {
    apiUrl = "https://localhost:7230/api/clientes";
    
    constructor(
        private http: HttpClient){ 

        }

    recuperar(id: number): Observable<clienteModel> {
        return this.http.get<clienteModel>(`${this.apiUrl}/recuperar/${id}`);
    }

    recuperarTodos(): Observable<clienteModel[]> {
        return this.http.get<clienteModel[]>(`${this.apiUrl}/todos`);
    }

    cadastrar(cliente: clienteModel): Observable<clienteModel> {
        cliente.tipoDeClienteSexo = cliente.tipoDeClienteSexo * 1;
        return this.http.post<clienteModel>(`${this.apiUrl}/cadastrar`, cliente).pipe(
            catchError(this.handleError)
          );;
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
}