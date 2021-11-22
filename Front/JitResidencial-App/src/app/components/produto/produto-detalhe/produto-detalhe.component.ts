
import { Component, OnInit }
        from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators }
        from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ValidarCampos } from '@app/helpers/ValidarCampos';
import { Produto } from '@app/models/Produtct';
import { ProdutoService } from '@app/Services/produto/produto.service';
import { BsLocaleService, DateFormatter } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-produto-detalhe',
  templateUrl: './produto-detalhe.component.html',
  styleUrls: ['./produto-detalhe.component.scss']
})
export class ProdutoDetalheComponent implements OnInit {

  produto = {} as Produto;
  form!: FormGroup;
  estadoSalvar = 'post';

  get f(): any {
    return this.form!.controls;
  }

  get bsConfig(): any {
    return { isAnimated: true,
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY hh:mm',
      containerClass: 'theme-default'
    };
  }

  constructor(private fb: FormBuilder,
              private localeServive: BsLocaleService,
              private router: ActivatedRoute,
              private produtoService: ProdutoService,
              private spinner: NgxSpinnerService,
              private toastr: ToastrService)
  {
    this.localeServive.use('pt-br')
  }

  public carregarProduto(): void {
    const produtoIdParam = this.router.snapshot.paramMap.get('id')

    if (produtoIdParam !== null) {
      this.spinner.show();

      this.estadoSalvar = 'put';
      this.produtoService.getProdutosById(+produtoIdParam).subscribe(
        (produto: Produto) => {
          this.produto = {... produto};
          this.form.patchValue(this.produto);
        },
        (error: any) => {
          this.toastr.error('Houve uma falha ao carregar o produto.', 'erro!')
          console.error(error);
        }
      ).add(() => this.spinner.hide());
    }
  }
  ngOnInit() {
    this.carregarProduto();
    this.validation();
  }

  public validation(): void {
      this.form! = this.fb.group({
        id: ["", ],
        codigoBarras: ["", [
                          Validators.required,
                          Validators.minLength(15),
                          Validators.maxLength(15)
                         ]],
      nomeProduto:  ["", [
                          Validators.required,
                          Validators.minLength(4),
                          Validators.maxLength(50)
                         ]],
      quantidade:  ["",  [
                          Validators.required,
                          Validators.max(999999)
                         ]],
      volume: ["", [
                    Validators.required,
                    Validators.minLength(4),
                    Validators.maxLength(15)
                   ]],
      dataValidade: ["", [
                          Validators.required
        ]],
        dataAlteracao: ["",],
      dataInclusao: ["",]
      });
  }
  resetForm(event: any): void {
    event.preventDefault();
    this.form.reset();
   }
  cssValidator(campoForm: FormControl): any {
    return ValidarCampos.verificarErroCampo(campoForm);
  }
  ErrorMessageValidationField(fieldName: FormControl, fieldElement: string): any {
    return ValidarCampos.retornarMensagemErro(fieldName, fieldElement);
  }
  public salvarProduto(): void {
    this.spinner.show();

    var data  = new Date().toLocaleString("pt-br");

    if (this.form.valid) {
      this.produto = (
        this.estadoSalvar === 'post')
        ? { ... this.form.value }
        : { id: this.produto.id, ... this.form.value };
      this.produto.dataAlteracao = data;
      if (this.estadoSalvar === 'post') {
        this.produto.dataInclusao = data;
      }

      this.produtoService[this.estadoSalvar](this.produto).subscribe(
        () => this.toastr.success("Produto atualizado com sucesso", "Sucesso!"),
        (error: any) => {
          console.error(error);
          this.toastr.error("Erro ao salvar produto", "Erro!");
        }
      ).add(() => this.spinner.hide());
    }

  }
}
