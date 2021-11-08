import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-usuario-login',
  templateUrl: './usuario-login.component.html',
  styleUrls: ['./usuario-login.component.scss']
})
export class LoginComponent implements OnInit {

  form!: FormGroup;

  get f(): any {
    return this.form!.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }
  public validation(): void {

    this.form! = this.fb.group({
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
}
