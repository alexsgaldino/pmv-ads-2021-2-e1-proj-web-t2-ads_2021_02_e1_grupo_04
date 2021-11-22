import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ValidarCampos } from '@app/helpers/ValidarCampos';
import { Conta } from '@app/models/Identity/Conta';
import { ContaService } from '@app/Services/conta/conta.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.scss']
})

export class CadastroComponent implements OnInit {

  cadastroForm: FormGroup;
  conta = {} as Conta;

  get controlsAtivo(): any {
    return this.cadastroForm.controls;
  }

  constructor(private router: Router,
              private fb: FormBuilder,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService,
              private contaService: ContaService)
  {

  }

  ngOnInit(): void {
    this.validation();
  }
  public validation(): void {

    const formOptions: AbstractControlOptions = {
      validators: ValidarCampos.comparaSenha('password', 'confirmPassword')
    };

    this.cadastroForm = this.fb.group({
      userName: ["",
        [
          Validators.required,
          Validators.minLength(8),
          Validators.maxLength(15)
        ]],
      primeiroNome: ["",
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(15)
        ]],
      sobrenome: ["",
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(50)
        ]],
      email: ["",
        [
          Validators.required,
          Validators.email
        ]],
      password: ["",
        [
          Validators.required,
          Validators.minLength(6)
        ]],
      confirmPassword: ["",
        [
          Validators.required
        ]],
      }, formOptions);
  }
  resetForm(event: any): void {
    event.preventDefault();
    this.cadastroForm.reset();
  }
  validarCampo(campoForm: FormControl): any {
    return ValidarCampos.verificarErroCampo(campoForm);
  }
  retornarValidacao(nomeCampo: FormControl, nomeElemento: string): any {
    return ValidarCampos.retornarMensagemErro(nomeCampo, nomeElemento);
  }
  cadastrarConta() {
    this.spinner.show();

    this.conta = { ... this.cadastroForm.value };
    this.contaService.cadastrar(this.conta).subscribe(
      () => this.router.navigateByUrl('/home'),
      (error: any) => this.toastr.error(error.error)
    ).add(() => this.spinner.hide());
    }
}
