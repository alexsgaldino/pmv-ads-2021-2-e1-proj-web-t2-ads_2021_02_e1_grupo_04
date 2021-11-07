/* ---------------------- ANGULAR IMPORTS ---------------------- */
import { BrowserAnimationsModule }          from '@angular/platform-browser/animations';
import { BrowserModule }                    from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule }                      from '@angular/forms';
import { HttpClientModule }                 from '@angular/common/http';

/* ---------------------- BOOTSTRAP IMPORTS ---------------------- */
import { BsDropdownModule }   from 'ngx-bootstrap/dropdown';
import { CollapseModule }     from 'ngx-bootstrap/collapse';
import { NgxSpinnerModule }   from 'ngx-spinner';
import { ModalModule }        from 'ngx-bootstrap/modal';
import { ToastContainerModule, ToastrModule }
                              from 'ngx-toastr';
import { TooltipModule }      from 'ngx-bootstrap/tooltip';

/* ---------------------- SUPPORT IMPORTS ---------------------- */
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

/* ---------------------- HELPERS IMPORTS ---------------------- */
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';

/* ---------------------- Serices IMPORTS ---------------------- */
import { ProdutoService } from './Services/produto/produto.service';

/* ---------------------- COMPONENTS IMPORTS ---------------------- */
import { CategoriaComponent }     from './components/categoria/categoria.component';
import { EnderecoComponent }      from './components/usuario/endereco/endereco.component';
import { EstoqueComponent }       from './components/estoque/estoque.component';
import { FooterComponent }        from './shared/footer/footer.component';
import { FornecedorComponent }    from './components/fornecedor/fornecedor.component';
import { GrupoComponent }         from './components/usuario/grupo/grupo.component';
import { HomeComponent }          from './components/home/home.component';
import { ListaPrecoComponent }    from './components/listaPreco/listaPreco.component';
import { NavComponent }           from './shared/nav/nav.component';
import { ProdutoComponent }      from './components/produto/produto.component';
import { TituloComponent }        from './shared/titulo/titulo.component';
import { UnidadeMedidaComponent } from './components/unidadeMedida/unidadeMedida.component';
import { UsuarioComponent }       from './components/usuario/usuario.component';
import { ProdutoDetalheComponent } from './components/produto/produtoDetalhe/produtoDetalhe.component';
import { ProdutoListaComponent } from './components/produto/produtoLista/produtoLista.component';
import { LoginComponent } from './components/usuario/login/login.component';
import { CadastroComponent } from './components/usuario/cadastro/cadastro.component';
import { UsuarioPerfilComponent } from './components/usuario/usuarioPerfil/usuarioPerfil.component';
import { UsuarioListaComponent } from './components/usuario/usuarioLista/usuarioLista.component';
import { UsuarioService } from './Services/usuario/usuario.service';

@NgModule({
  declarations: [
    AppComponent,
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
    TituloComponent,
    UnidadeMedidaComponent,
    UsuarioComponent,
    ProdutoDetalheComponent,
    ProdutoListaComponent,
    LoginComponent,
    CadastroComponent,
    UsuarioPerfilComponent,
    UsuarioListaComponent,
   ],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    BsDropdownModule.forRoot(),
    CollapseModule.forRoot(),
    FormsModule,
    HttpClientModule,
    ModalModule.forRoot(),
    NgxSpinnerModule,
    ToastContainerModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar: true,
    }),
    TooltipModule.forRoot(),
  ],
  providers: [ProdutoService, UsuarioService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
