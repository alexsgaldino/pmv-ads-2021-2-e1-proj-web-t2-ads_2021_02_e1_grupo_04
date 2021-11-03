import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriaComponent } from './componentes/Categoria/Categoria.component';
import { EnderecoComponent } from './componentes/Endereco/Endereco.component';
import { EstoqueComponent } from './componentes/Estoque/Estoque.component';
import { FornecedorComponent } from './componentes/Fornecedor/Fornecedor.component';
import { GrupoComponent } from './componentes/Grupo/Grupo.component';
import { HomeComponent } from './componentes/home/home.component';
import { ListaPrecoComponent } from './componentes/ListaPreco/ListaPreco.component';
import { ProdutosComponent } from './componentes/Produtos/Produtos.component';
import { UnidadeMedidaComponent } from './componentes/UnidadeMedida/UnidadeMedida.component';
import { UsuarioComponent } from './componentes/Usuario/Usuario.component';

const routes: Routes = [
  { path: 'produtos', component: ProdutosComponent },
  { path: 'categoria', component: CategoriaComponent },
  { path: 'endereco', component: EnderecoComponent },
  { path: 'estoque', component: EstoqueComponent },
  { path: 'fornecedor', component: FornecedorComponent },
  { path: 'grupo', component: GrupoComponent },
  { path: 'home', component: HomeComponent },
  { path: 'listapreco', component: ListaPrecoComponent },
  { path: 'unidadeMedida', component: UnidadeMedidaComponent },
  { path: 'usuario', component: UsuarioComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
