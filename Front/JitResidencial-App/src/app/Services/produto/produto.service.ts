import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { take } from 'rxjs/operators'

import { Produto } from '@app/models/Produto';

@Injectable()
export class ProdutoService {

  baseURL = ' https://localhost:5001/api/produtos';

  constructor(private http: HttpClient) {

  }

  public getProdutos(): Observable<Produto[]> {
    return this.http
      .get<Produto[]>(this.baseURL)
      .pipe(take(1));
  }

  public getProdutosByNomeProduto(nomeProduto: string): Observable<Produto[]> {
    return this.http
      .get<Produto[]>(`${this.baseURL}/{${nomeProduto}/nomeProduto`)
      .pipe(take(1));
  }

  public getProdutosById(id: number): Observable<Produto> {
    return this.http
      .get<Produto>(`${this.baseURL}/${id}`)
      .pipe(take(1));
  }

  public post(produto: Produto): Observable<Produto> {
    return this.http
      .post<Produto>(this.baseURL, produto)
      .pipe(take(1));
  }

  public put(produto: Produto): Observable<Produto> {
    return this.http
      .put<Produto>(`${this.baseURL}/${produto.id}`, produto)
      .pipe(take(1));
  }

  public deleteProduto(id: number): Observable<any> {
    return this.http
      .delete(`${this.baseURL}/${id}`)
      .pipe(take(1));
  }
}

