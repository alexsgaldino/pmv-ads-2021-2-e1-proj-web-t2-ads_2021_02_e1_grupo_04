/* ---------------------- ANGULAR IMPORTS ---------------------- */
import { BrowserAnimationsModule }
        from '@angular/platform-browser/animations';
import { BrowserModule }
        from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule }
        from '@angular/core';
import { CommonModule }
        from '@angular/common';
import { FormsModule, ReactiveFormsModule }
        from '@angular/forms';
import { HttpClientModule }
        from '@angular/common/http';

/* ---------------------- BOOTSTRAP IMPORTS ---------------------- */
import {BsDatepickerModule}
        from 'ngx-bootstrap/datepicker';
import { BsDropdownModule }
        from 'ngx-bootstrap/dropdown';
import { CollapseModule }
        from 'ngx-bootstrap/collapse';
import { NgxSpinnerModule }
        from 'ngx-spinner';
import { ModalModule }
        from 'ngx-bootstrap/modal';
import { ToastContainerModule, ToastrModule }
        from 'ngx-toastr';
import { TooltipModule }
        from 'ngx-bootstrap/tooltip';

/* ---------------------- SUPPORT IMPORTS ---------------------- */
import { AppComponent }
        from './app.component';
import { AppRoutingModule }
        from './app-routing.module';

/* ---------------------- HELPERS IMPORTS ---------------------- */
import { DateTimeFormatPipe }
        from './helpers/DateTimeFormat.pipe';

/* ---------------------- Serices IMPORTS ---------------------- */
import { ProdutoService }
        from './Services/produto/produto.service';

/* ---------------------- COMPONENTS IMPORTS ---------------------- */
import { LoginComponent }  from './components/User/login/login.component';
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
import { UsuarioComponent }       from './components/usuario/usuario.component';
import { ProdutoListaComponent }  from './components/produto/produto-lista/produto-lista.component';
import { RegistrationComponent }
                                  from './components/User/Registration/registration.component';
import { ProfileComponent } from './components/User/Profile/profile.component';
import { UsuarioListaComponent }  from './components/usuario/usuarioLista/usuario-lista.component';
import { UserService }         from './Services/user/user.service';
import { defineLocale }           from 'ngx-bootstrap/chronos';
import { ptBrLocale }             from 'ngx-bootstrap/locale';

defineLocale('pt-br', ptBrLocale);
@NgModule({
  declarations: [
    AppComponent,

    LoginComponent,
    ProfileComponent,
    RegistrationComponent,
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
    UsuarioComponent,

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
  providers: [ProdutoService, UserService],
  bootstrap: [AppComponent],
  exports: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
