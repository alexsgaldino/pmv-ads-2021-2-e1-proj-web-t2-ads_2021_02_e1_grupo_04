import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriaComponent } from './components/categoria/categoria.component';
import { EnderecoComponent } from './components/usuario/endereco/endereco.component';
import { EstoqueComponent } from './components/estoque/estoque.component';
import { FornecedorComponent }
        from './components/fornecedor/fornecedor.component';
import { GrupoComponent }
        from './components/usuario/grupo/grupo.component';
import { HomeComponent }
        from './components/home/home.component';
import { ListaPrecoComponent }
        from './components/listaPreco/listaPreco.component';
import { ProdutoDetalheComponent }
        from './components/produto/produto-detalhe/produto-detalhe.component';
import { ProdutoListaComponent }
        from './components/produto/produto-lista/produto-lista.component';
import { ProdutoComponent }
        from './components/produto/produto.component';
import { UnidadeMedidaComponent }
        from './components/unidadeMedida/unidadeMedida.component';
import { RegistrationComponent }
        from './components/User/Registration/registration.component';
import { LoginComponent }
        from './components/User/login/login.component';
import { ProfileComponent }
        from './components/User/Profile/profile.component';
import { UsuarioComponent }
        from './components/usuario/usuario.component';
import { UsuarioListaComponent }
        from './components/usuario/usuarioLista/usuario-lista.component';


const routes: Routes = [
  { path: 'usuario', redirectTo: 'usuario/lista' },
  { path: 'produto', redirectTo: 'produto/lista' },
  {
    path: 'user', component: UsuarioComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'profile', component: ProfileComponent},
      { path: 'registration', component: RegistrationComponent },
      { path: 'perfil/:id', component: UsuarioListaComponent },
      { path: 'lista', component: UsuarioListaComponent },
     ]
  },
  {
    path: 'produto', component: ProdutoComponent,
    children: [
      {path: 'detalhe/:id', component: ProdutoDetalheComponent},
      {path: 'detalhe', component: ProdutoDetalheComponent},
      {path: 'lista', component: ProdutoListaComponent},
    ]
   },
  { path: 'categoria', component: CategoriaComponent },
  { path: 'user/endereco', component: EnderecoComponent },
  { path: 'estoque', component: EstoqueComponent },
  { path: 'fornecedor', component: FornecedorComponent },
  { path: 'usuario/grupo', component: GrupoComponent },
  { path: 'home', component: HomeComponent },
  { path: 'listapreco', component: ListaPrecoComponent },
  { path: 'unidadeMedida', component: UnidadeMedidaComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
