import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ValidarCampos } from '@app/helpers/ValidarCampos';
import { Conta } from '@app/models/Identity/Conta';
import { Login } from '@app/models/Identity/Login';
import { ContaService } from '@app/Services/conta/conta.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  model = {} as Login;


  formLogin: FormGroup;

  public conta: Conta[] = [];

  get controlsAtivo(): any {
    return this.formLogin.controls;
  }

  constructor(private fb: FormBuilder,
    private contaService: ContaService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private router: Router) {
  }

  ngOnInit(): void {
    this.validarFormulario();
  }

  login(): void
  {
    this.contaService.login(this.model).subscribe(
      () => { this.router.navigateByUrl('/home'); },
      (error: any) => {
        if (error.status == 401)
          this.toastr.error('Conta ou senha inválido');
        else
          console.error(error);
      }
    );
  }

  public validarFormulario(): void {

    this.formLogin = this.fb.group({
      userName: ["", [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(15)
      ]],
      password: ["", [
        Validators.required,
        Validators.minLength(6)
      ]],
    });
  }
  validarCampo(campoForm: FormControl): any {
    return ValidarCampos.verificarErroCampo(campoForm);
  }

  retornarValidacao(nomeCampo: FormControl, elementoCampo: string): any {
    return ValidarCampos.retornarMensagemErro(nomeCampo, elementoCampo);
  }

  validarSenha(): void {
    this.spinner.show();

    this.contaService
      .recuperarConta(this.formLogin.value.userName)
      .subscribe(
        (conta: Conta[]) => { this.conta = conta },
        (error: any) => {
          this.toastr.error('Houve uma falha ao carregar o usuario', "Erro!")
          console.error(error);
        },
      ).add(() => this.spinner.hide());

      console.log("usuario:", this.conta, this.formLogin)
  }

}
