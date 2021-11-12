import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ValidationFields } from '@app/helpers/validationFields';
import { User } from '@app/models/User';
import { UserService } from '@app/Services/user/user.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  model: any = {}


  formLogin: FormGroup;

  public Users: User[] = [];

  get f(): any {
    return this.formLogin.controls;
  }

  constructor(private fb: FormBuilder,
    private userService: UserService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    public router: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.validation();
  }

  login()
  {
    console.log();
  }






  public validation(): void {

    this.formLogin = this.fb.group({
      usuarioLogin: ["", [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(15)
      ]],
      senha: ["", [
        Validators.required,
        Validators.minLength(6)
      ]],
    });
  }
  cssValidator(campoForm: FormControl): any {
    return ValidationFields.VerifyErrorsTouched(campoForm);
  }

  ErrorMessageValidationField(fieldName: FormControl, fieldElement: string): any {
    return ValidationFields.ReturnMessageGroup(fieldName, fieldElement);
  }

  validarUsuarioSenha(): void {
    this.spinner.show();

    this.userService
      .getUserName(this.formLogin.value.userName)
      .subscribe(
        (users: User[]) => { this.Users = users },
        (error: any) => {
          this.toastr.error('Houve uma falha ao carregar o usuario', "Erro!")
          console.error(error);
        },
      ).add(() => this.spinner.hide());

      console.log("usuario:", this.Users, this.formLogin)
  }

}
