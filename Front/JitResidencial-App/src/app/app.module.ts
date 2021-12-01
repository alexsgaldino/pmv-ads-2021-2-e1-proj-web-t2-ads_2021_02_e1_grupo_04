

import { CUSTOM_ELEMENTS_SCHEMA,
          }                 from '@angular/core';
import { CommonModule }             from '@angular/common';
import { FormsModule,
         ReactiveFormsModule }      from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS }         from '@angular/common/http';




import { NgxSpinnerModule }         from 'ngx-spinner';

import { ToastContainerModule,
         ToastrModule }             from 'ngx-toastr';



import { AppComponent }             from './app.component';




import { ProdutoService }           from './Services/produto/produto.service';
import { ContaService }             from './Services/conta/conta.service';


import { LoginComponent }           from './components/conta/login/login.component';

import { ProdutoDetalheComponent } from './components/produto/produto-detalhe/produto-detalhe.component';

import { CategoriaComponent }     from './components/categoria/categoria.component';
import { EnderecoComponent }      from './components/usuario/endereco/endereco.component';
import { EstoqueComponent }       from './components/estoque/estoque.component';
import { FooterComponent }        from './shared/footer/footer.component';
import { FornecedorComponent }    from './components/fornecedor/fornecedor.component';
import { GrupoComponent }         from './components/usuario/grupo/grupo.component';
import { HomeComponent }          from './components/home/home.component';
import { ListaPrecoComponent }    from './components/listaPreco/listaPreco.component';
import { ProdutoComponent }       from './components/produto/produto.component';
import { UnidadeMedidaComponent } from './components/unidadeMedida/unidadeMedida.component';
import { ContaComponent }       from './components/conta/conta.component';
import { CadastroComponent }
                                  from './components/conta/cadastro/cadastro.component';
import { ProfileComponent } from './components/User/Profile/profile.component';
import { UsuarioListaComponent }  from './components/usuario/usuarioLista/usuario-lista.component';
import { defineLocale }           from 'ngx-bootstrap/chronos';
import { ptBrLocale }             from 'ngx-bootstrap/locale';
import { JwtInterceptor } from './interceptors/jwt.interceptor';


defineLocale('pt-br', ptBrLocale);
@NgModule({
  declarations: [

    LoginComponent,
    ContaComponent,

    ProfileComponent,
    CadastroComponent,

    CategoriaComponent,
     EnderecoComponent,
    EstoqueComponent,
    FooterComponent,
    FornecedorComponent,
    GrupoComponent,
    HomeComponent,
    ListaPrecoComponent,
    ProdutoComponent,
    ProdutoDetalheComponent,

    UnidadeMedidaComponent,


    UsuarioListaComponent,


   ],
  imports: [
    BsDatepickerModule.forRoot(),
    CommonModule,

    NgxSpinnerModule,
    ReactiveFormsModule,
    ToastContainerModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar: true,
    }),
  ],
  providers: [ProdutoService, ContaService,
  { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}],
  exports: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
