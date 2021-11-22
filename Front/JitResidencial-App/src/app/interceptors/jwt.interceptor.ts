import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Conta } from '@app/models/Identity/Conta';
import { ContaService } from '@app/Services/conta/conta.service';
import { take } from 'rxjs/operators';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private contaService: ContaService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let contaAtual: Conta;

    this.contaService.contaAtual$.pipe(take(1)).subscribe(conta => {
      contaAtual = conta

      if (contaAtual) {
        request = request.clone({
            setHeaders: {
              Authorization: `Bearer ${contaAtual.token}`
            }
          }
        );
      }
    });
    return next.handle(request);
  }
}
