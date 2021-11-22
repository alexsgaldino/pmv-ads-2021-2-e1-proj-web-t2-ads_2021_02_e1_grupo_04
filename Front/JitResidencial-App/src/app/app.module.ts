/* ---------------------- ANGULAR IMPORTS ---------------------- */
import { BrowserAnimationsModule }  from '@angular/platform-browser/animations';
import { BrowserModule }            from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA,
         NgModule }                 from '@angular/core';
import { CommonModule }             from '@angular/common';
import { FormsModule,
         ReactiveFormsModule }      from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS }         from '@angular/common/http';

/* ---------------------- BOOTSTRAP IMPORTS ---------------------- */
import {BsDatepickerModule}         from 'ngx-bootstrap/datepicker';
import { BsDropdownModule }         from 'ngx-bootstrap/dropdown';
import { CollapseModule }           from 'ngx-bootstrap/collapse';
import { NgxSpinnerModule }         from 'ngx-spinner';
import { ModalModule }              from 'ngx-bootstrap/modal';
import { ToastContainerModule,
         ToastrModule }             from 'ngx-toastr';
import { TooltipModule }            from 'ngx-bootstrap/tooltip';

/* ---------------------- SUPPORT IMPORTS ---------------------- */
import { AppComponent }             from './app.component';
import { AppRoutingModule }         from './app-routing.module';

/* ---------------------- HELPERS IMPORTS ---------------------- */
import { DateTimeFormatPipe }       from './helpers/DateTimeFormat.pipe';

/* ---------------------- Serices IMPORTS ---------------------- */
import { ProdutoService }           from './Services/produto/produto.service';
import { ContaService }             from './Services/conta/conta.service';

/* ---------------------- COMPONENTS IMPORTS ---------------------- */
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
import { NavComponent }           from './shared/nav/nav.component';
import { ProdutoComponent }       from './components/produto/produto.component';
import { TitleComponent }        from './shared/title/title.component';
import { UnidadeMedidaComponent } from './components/unidadeMedida/unidadeMedida.component';
import { ContaComponent }       from './components/conta/conta.component';
import { ProdutoListaComponent }  from './components/produto/produto-lista/produto-lista.component';
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
    AppComponent,

    LoginComponent,
    ContaComponent,

    ProfileComponent,
    CadastroComponent,
    TitleComponent,

    CategoriaComponent,
    DateTimeFormatPipe,
    EnderecoComponent,
    EstoqueComponent,
    FooterComponent,
    FornecedorComponent,
    GrupoComponent,
    HomeComponent,
    ListaPrecoComponent,
    NavComponent,
    ProdutoComponent,
    ProdutoDetalheComponent,
    ProdutoListaComponent,

    UnidadeMedidaComponent,


    UsuarioListaComponent,


   ],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    BsDatepickerModule.forRoot(),
    BsDropdownModule.forRoot(),
    CollapseModule.forRoot(),
    CommonModule,
    FormsModule,
    HttpClientModule,
    ModalModule.forRoot(),
    NgxSpinnerModule,
    ReactiveFormsModule,
    ToastContainerModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar: true,
    }),
    TooltipModule.forRoot(),
  ],
  providers: [ProdutoService, ContaService,
  { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}],
  bootstrap: [AppComponent],
  exports: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
