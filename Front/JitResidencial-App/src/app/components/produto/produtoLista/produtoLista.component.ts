import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { Component, OnInit, TemplateRef, ViewChild}
                                      from "@angular/core";
import { NgxSpinnerService }          from "ngx-spinner";
import { ToastContainerDirective, ToastrService }
                                      from "ngx-toastr";
import { Produto } from "src/app/models/Produto";
import { ProdutoService } from "src/app/Services/produto/produto.service";
import { Router } from "@angular/router";

@Component ({
  selector: 'app-produtos',
  templateUrl: './produtoLista.component.html',
  styleUrls: ['./produtoLista.component.scss']
})
export class ProdutoListaComponent implements OnInit {
  modalRef!: BsModalRef;

  @ViewChild(ToastContainerDirective) toastContainer?: ToastContainerDirective;

  public produtos: Produto[] = [];
  public produtosFiltrados: Produto[] = [];
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.produtosFiltrados = this._filtroLista ? this.filtrarProdutos(this.filtroLista) : this.produtos;
  }

  public filtrarProdutos(filtrarPor: string): Produto[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.produtos.filter(
      (produto: any) => produto.nomeProduto.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
                        produto.volume.toLocaleLowerCase().indexOf(filtrarPor) !== -1

      );
    }

  constructor(private produtoService: ProdutoService,
              private modalServices: BsModalService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService,
              private router: Router
              ) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.getProdutos();
    this.toastr.overlayContainer = this.toastContainer;
  }

  public getProdutos(): void {
    this.produtoService.getProdutos().subscribe({
      next: (produtos: Produto[]) => {
        this.produtos = produtos;
        this.produtosFiltrados = this.produtos;
      },
      error: error => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os produtos', 'Erro!');
      },
      complete: () => this.spinner.hide()
    });
  }
  openModal (template: TemplateRef<any>): void {
    this.modalRef = this.modalServices.show(template, {class: 'modal-sm'});
  }
  confirm(): void {
    this.modalRef.hide();
    this.toastr.success('Registro excluído', 'deletado');
  }
  decline(): void {
    this.modalRef.hide();
  }
  detalheProduto(id: number): void {
    this.router.navigate([`produto/detalhe/${id}`]);
  }
}
