import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidationFields } from '@app/helpers/validationFields';

@Component({
  selector: 'app-usuario-perfil',
  templateUrl: './usuario-perfil.component.html',
  styleUrls: ['./usuario-perfil.component.scss']
})
export class UsuarioPerfilComponent implements OnInit {

  form!: FormGroup;

  get f(): any {
    return this.form!.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }
  public validation(): void {
    const formOptions: AbstractControlOptions = {
      validators: ValidationFields.MustMatch('senha', 'confirmarSenha')
    };

    this.form! = this.fb.group({
      usuarioLogin: ["", [
                          Validators.required,
                          Validators.minLength(8),
                          Validators.maxLength(15)
                         ]],
      primeiroNome:  ["", [
                          Validators.required,
                          Validators.minLength(4),
                          Validators.maxLength(15)
                         ]],
      sobrenome:  ["",  [
                          Validators.required,
                          Validators.minLength(4),
                          Validators.maxLength(50)
                         ]],
      email: ["", [
                    Validators.required,
                    Validators.email
                   ]],
      telefone: ["", [
                      Validators.required
                      ]],
      senha: ["", [
                    Validators.required,
                    Validators.minLength(6)
                    ]],
      confirmarSenha: ["", [
                            Validators.required
                            ]],
      }, formOptions);
  }
  resetForm(): void {
    this.form.reset();
   }
}
