import { Component, OnInit } from '@angular/core';
import { AbstractControl, AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ValidationFields } from '@app/helpers/validationFields';
import { User } from '@app/models/User';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '@app/Services/user/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})

export class RegistrationComponent implements OnInit {

  registerForm: FormGroup;
  user: User;

  get f(): any {
    return this.registerForm.controls;
  }

  constructor(private router: Router,
              private fb: FormBuilder,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService,
              private userService: UserService)
  {

  }

  ngOnInit(): void {
    this.validation();
  }
  public validation(): void {

    const formOptions: AbstractControlOptions = {
      validators: ValidationFields.MustMatch('password', 'confirmPassword')
    };

    this.registerForm = this.fb.group({
      userName: ["",
        [
          Validators.required,
          Validators.minLength(8),
          Validators.maxLength(15)
        ]],
      firstName: ["",
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(15)
        ]],
      lastName: ["",
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
    this.registerForm.reset();
  }
  fieldValidator(campoForm: FormControl): any {
    return ValidationFields.VerifyErrorsTouched(campoForm);
  }
  ErrorMessageValidationField(fieldName: FormControl, fieldElement: string): any {
    return ValidationFields.ReturnMessageGroup(fieldName, fieldElement);
  }
  registrationUser() {
    this.spinner.show();


    if (this.registerForm.valid) {

      this.user = Object
        .assign({ password: this.registerForm.get('password').value },
          this.registerForm.value);

      this.userService.getUserName(this.user.userName).subscribe(
        () =>
        {
          this.toastr.error('Conta já cadastrada, tente novamente', 'erro!')
        },
        (error: any) =>
        {
          console.error(error);
        }
      ).add(() => this.spinner.hide());

    /*  this.userService.post(this.user).subscribe(
        () => {
          this.router.navigate(['/user/login']);
          this.toastr.success('Conta criada.')
        },
        erro => {
          console.error(erro);
          console.log(erro)
          erro.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                this.toastr.error('Esta conta já existe!');
                break;
              default:
                this.toastr.error(`Esta na criação da conta! CODE: ${element.code}`);
                break;
            }
          });
        }
      ).add(() => this.spinner.hide());
      */}
    }
}
