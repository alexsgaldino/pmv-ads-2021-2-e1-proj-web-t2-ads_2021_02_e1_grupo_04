import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { Component, OnInit, TemplateRef, ViewChild}
                                      from "@angular/core";
import { NgxSpinnerService }          from "ngx-spinner";
import { ToastContainerDirective, ToastrService }
                                      from "ngx-toastr";
import { Router } from "@angular/router";
import { Conta } from "@app/models/Identity/Conta";
import { ContaService } from "@app/Services/conta/conta.service";

@Component ({
  selector: 'app-usuario-lista',
  templateUrl: './usuario-lista.component.html',
  styleUrls: ['./usuario-lista.component.scss']
})
export class UsuarioListaComponent implements OnInit {
  modalRef!: BsModalRef;

  @ViewChild(ToastContainerDirective) toastContainer?: ToastContainerDirective;

  public usuarios: Conta[] = [];
  public usuariosFiltrados: Conta[] = [];
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.usuariosFiltrados = this._filtroLista ? this.filtrarUsuarios(this.filtroLista) : this.usuarios;
  }

  public filtrarUsuarios(filtrarPor: string): Conta[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.usuarios.filter(
      (usuario: any) => usuario.primeiroNome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
                        usuario.sobrenome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
                        usuario.usuario.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
                        usuario.email.toLocaleLowerCase().indexOf(filtrarPor) !== -1

      );
    }

  constructor(private ContaService: ContaService,
              private modalServices: BsModalService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService,
              private router: Router
              ) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.getUsuarios();
    this.toastr.overlayContainer = this.toastContainer;
  }

  public getUsuarios(): void {
    /*this.ContaService.getContasByFirstName().subscribe({
      next: (usuarios: Conta[]) => {
        this.usuarios = usuarios;
        this.usuariosFiltrados = this.usuarios;
      },
      error: error => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os usurios', 'Erro!');
      },
      complete: () => this.spinner.hide()
    });*/
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
  detalheUsuario(id: number): void {
    this.router.navigate([`usuario/perfil/${id}`]);
  }
}
