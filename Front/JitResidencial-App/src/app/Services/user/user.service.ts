import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { take } from 'rxjs/operators'

import { User } from 'src/app/models/User';

@Injectable()
export class UserService {

  baseURL = ' https://localhost:5001/api/User' ;

  constructor(private http: HttpClient) {

  }
  public getUserName(userName: string): Observable<User[]> {
  return this.http
    .get<User[]>(`${this.baseURL}/{${userName}/userName`)
    .pipe(take(1));
  }
  public getUsersByfirstName(firstName: string): Observable<User[]> {
    return this.http
      .get<User[]>(`${this.baseURL}/{${firstName}/firstName`)
      .pipe(take(1));
  }

  public getUsersBylastName(flastName: string): Observable<User[]> {
    return this.http
      .get<User[]>(`${this.baseURL}/{${flastName}/flastName`)
      .pipe(take(1));
  }

  public getUser(userName: string): Observable<User[]> {
    return this.http
      .get<User[]>(`${this.baseURL}/{${userName}/userName`)
      .pipe(take(1));
  }

  public getUsersByEmail(email: string): Observable<User[]> {
    return this.http
      .get<User[]>(`${this.baseURL}/{${email}/email`)
      .pipe(take(1));
  }

  public getUserById(id: number): Observable<User> {
    return this.http
      .get<User>(`${this.baseURL}/${id}`)
      .pipe(take(1));
  }

  public post(User: User): Observable<User> {
    return this.http
      .post<User>(this.baseURL, User)
      .pipe(take(1));
  }

  public put(User: User): Observable<User> {
    return this.http
      .put<User>(`${this.baseURL}/${User.id}`, User)
      .pipe(take(1));
  }

  public deleteUser(id: number): Observable<any> {
    return this.http
      .delete(`${this.baseURL}/${id}`)
      .pipe(take(1));
  }
}
