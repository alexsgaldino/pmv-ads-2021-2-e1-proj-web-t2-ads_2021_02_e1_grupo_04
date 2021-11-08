import { Component, OnInit }
        from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators }
        from '@angular/forms';

@Component({
  selector: 'app-produto-detalhe',
  templateUrl: './produto-detalhe.component.html',
  styleUrls: ['./produto-detalhe.component.scss']
})
export class ProdutoDetalheComponent implements OnInit {

  form!: FormGroup;

  get f(): any {
    return this.form!.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.validation();
  }

  public validation(): void {
    this.form! = this.fb.group({
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
      });
  }
  resetForm(): void {
   this.form.reset();
  }
}
