import { AbstractControl, FormControl, FormGroup } from "@angular/forms";

export class ValidarCampos {
  static comparaSenha(password: string, confirmPassword: string): any {
    return (group: AbstractControl) => {
      const formGroup = group as FormGroup;
      const control = formGroup.controls[password];
      const matchingControl = formGroup.controls[confirmPassword];

      if (matchingControl.errors && !matchingControl.errors.mustMatch) {
        return null;
      }

      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({mustMatch: true});
      } else {
        matchingControl.setErrors(null);
      }

      return null;
    };
  }
  static verificarErroCampo(nomeCampo: FormControl): any {
    return {'is-invalid': nomeCampo.errors && nomeCampo.touched };
  }
  static retornarMensagemErro(nomeCampo: FormControl,
                              elementoCampo: string): any {
    if (nomeCampo.errors?.required)
    {
      return `${elementoCampo} obrigatório.`;
    }

    if (nomeCampo.errors?.minlength)
    {
      return `${elementoCampo} deve conter no mínimo ${nomeCampo.errors?.minlength.requiredLength} dígitos.`;
    }
    if (nomeCampo.errors?.maxlength)
    {
      return `${elementoCampo} deve conter no máximo ${nomeCampo.errors?.maxlength.requiredLength} dígitos.`;
    }
    if (nomeCampo.errors?.max)
    {
      return `${elementoCampo} limitada a  ${nomeCampo.errors?.max.max} unidades.`;
    }
    if (nomeCampo.errors?.email )
    {
      return `${elementoCampo} inválido.`;
    }

    if (elementoCampo == "Confirmar Senha")
    {

      if (nomeCampo.errors)
      {
        return "Confirmação de Senha inválido.";
        }
        }
  }
}
