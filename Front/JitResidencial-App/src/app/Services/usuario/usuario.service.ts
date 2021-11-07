import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from 'src/app/models/Usuario';

@Injectable()
export class UsuarioService {

  baseURL = ' https://localhost:5001/api/usuarios' ;

  constructor(private http: HttpClient) { }

  public getUsuarios(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.baseURL);
    }
  public getUsuariosByPrimeiroNome(primeiroNome: string): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(`${this.baseURL}/{${primeiroNome}/primeiroNome`);
    }
  public getUsuariosBySobrenome(sobrenome: string): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(`${this.baseURL}/{${sobrenome}/sobrenome`);
    }
  public getUsuariosByUsuario(usuario: string): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(`${this.baseURL}/{${usuario}/usuario`);
    }
  public getUsuariosByEmail(email: string): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(`${this.baseURL}/{${email}/email`);
    }
  public getUsuarioById(id: number): Observable<Usuario> {
    return this.http.get<Usuario>(`${this.baseURL}/${id}`);
    }
  }
