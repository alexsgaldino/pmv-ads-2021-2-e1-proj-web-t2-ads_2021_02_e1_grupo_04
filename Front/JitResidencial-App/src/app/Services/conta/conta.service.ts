import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Conta } from '@app/models/Identity/Conta';
import { environment } from '@environments/environment';
import { Observable, ReplaySubject } from 'rxjs';
import { map, take } from 'rxjs/operators';

@Injectable()
export class ContaService {
  [x: string]: any;
  private recurosContaAtual = new ReplaySubject<Conta>(1);
  public ContAtual$ = this.recurosContaAtual.asObservable();

//  baseUrl = environment.apiURL + 'api/conta/';
  baseURL = ' https://localhost:5001/api/Conta/';

  constructor(private http: HttpClient) { }

    public recuperarConta(conta: string): Observable<Conta[]> {
  return this.http
    .get<Conta[]>(`${this.baseURL}/{${conta}/conta}`)
    .pipe(take(1));
  }
  public getContasByfirstName(firstName: string): Observable<Conta[]> {
    return this.http
      .get<Conta[]>(`${this.baseURL}/{${firstName}/firstName`)
      .pipe(take(1));
  }

  public getContasBylastName(lastName: string): Observable<Conta[]> {
    return this.http
      .get<Conta[]>(`${this.baseURL}/{${lastName}/lastName`)
      .pipe(take(1));
  }

  public getConta(ContaName: string): Observable<Conta[]> {
    return this.http
      .get<Conta[]>(`${this.baseURL}/{${ContaName}/ContaName`)
      .pipe(take(1));
  }

  public getContasByEmail(email: string): Observable<Conta[]> {
    return this.http
      .get<Conta[]>(`${this.baseURL}/{${email}/email`)
      .pipe(take(1));
  }

  public getContaById(id: number): Observable<Conta> {
    return this.http
      .get<Conta>(`${this.baseURL}/${id}`)
      .pipe(take(1));
  }

  public post(Conta: Conta): Observable<Conta> {
    return this.http
      .post<Conta>(this.baseURL, Conta)
      .pipe(take(1));
  }

  public put(Conta: Conta): Observable<Conta> {
    return this.http
      .put<Conta>(`${this.baseURL}/${Conta.id}`, Conta)
      .pipe(take(1));
  }

  public deleteConta(id: number): Observable<any> {
    return this.http
      .delete(`${this.baseURL}/${id}`)
      .pipe(take(1));
  }

  public login(model: any): Observable<void> {
    return this.http.post<Conta>(this.baseURL + 'Login', model).pipe(
      take(1),
      map((response: Conta) => {
        const conta = response;
        if (conta) {
          this.definirContaAutal(conta)
        }
      })
    );
  }
  logout(): void {
    localStorage.removeItem('Conta');
    this.recurosContaAtual.next(null);
    this.recurosContaAtual.complete();
  }

  public definirContaAutal(conta: Conta): void {
    localStorage.setItem('Conta', JSON.stringify(conta));
    this.recurosContaAtual.next(conta);
  }
  public cadastrar(model: any): Observable<void> {
    return this.http.post<Conta>(this.baseURL + 'RegistrarConta', model).pipe(
      take(1),
      map((response: Conta) => {
        const conta = response;
        if (conta) {
          this.definirContaAutal(conta)
        }
      })
    );
  }
}
