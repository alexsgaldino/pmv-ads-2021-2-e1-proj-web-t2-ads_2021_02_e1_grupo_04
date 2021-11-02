import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";

@Component ({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.scss']
})
export class ProdutosComponent implements OnInit {

  public produtos: any = [];
  public produtosFiltrados: any = [];
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.produtosFiltrados = this._filtroLista ? this.filtrarProdutos(this.filtroLista) : this.produtos;
  }

  filtrarProdutos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.produtos.filter(
      (produto: any) => produto.nomeProduto.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
                        produto.volume.toLocaleLowerCase().indexOf(filtrarPor) !== -1 

      );
    }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getProdutos();
  }

  public getProdutos(): void {
    this.http.get('https://localhost:5001/api/produtos').subscribe(
      response => {
        this.produtos = response;
        this.produtosFiltrados = this.produtos;
      },
      error => console.log(error)
    );
  }
}
