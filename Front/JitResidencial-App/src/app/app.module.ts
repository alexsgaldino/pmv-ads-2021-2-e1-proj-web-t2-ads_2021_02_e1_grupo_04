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
import { ProdutoService } from './Services/produto.service';

/* ---------------------- COMPONENTS IMPORTS ---------------------- */
import { CategoriaComponent }     from './componentes/Categoria/Categoria.component';
import { EnderecoComponent }      from './componentes/Endereco/Endereco.component';
import { EstoqueComponent }       from './componentes/Estoque/Estoque.component';
import { FooterComponent }        from './shared/footer/footer.component';
import { FornecedorComponent }    from './componentes/Fornecedor/Fornecedor.component';
import { GrupoComponent }         from './componentes/Grupo/Grupo.component';
import { HomeComponent }          from './componentes/home/home.component';
import { ListaPrecoComponent }    from './componentes/ListaPreco/ListaPreco.component';
import { NavComponent }           from './shared/nav/nav.component';
import { ProdutosComponent }      from './componentes/Produtos/Produtos.component';
import { TituloComponent }        from './shared/titulo/Titulo.component';
import { UnidadeMedidaComponent } from './componentes/UnidadeMedida/UnidadeMedida.component';
import { UsuarioComponent }       from './componentes/Usuario/Usuario.component';


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
    ProdutosComponent,
    TituloComponent,
    UnidadeMedidaComponent,
    UsuarioComponent,
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
  providers: [ProdutoService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
