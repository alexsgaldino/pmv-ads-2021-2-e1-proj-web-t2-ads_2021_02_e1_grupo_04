import { AbstractControl, FormControl, FormGroup } from "@angular/forms";

export class ValidationFields {
  static MustMatch(controlName: string, matchingControlName: string): any {
    return (group: AbstractControl) => {
      const formGroup = group as FormGroup;
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

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
  static VerifyErrorsTouched(fieldName: FormControl): any {
    return {'is-invalid': fieldName.errors && fieldName.touched };
  }
  static ReturnMessageGroup(fieldName: FormControl,
                            fieldElement: string): any {
    console.log("!!!!!!", fieldName.value);
    if (fieldName.errors?.required)
    {
      return `${fieldElement} obrigatório.`;
    }

    if (fieldName.errors?.minlength)
    {
      return `${fieldElement} deve conter no mínimo ${fieldName.errors?.minlength.requiredLength} dígitos.`;
    }
    if (fieldName.errors?.maxlength)
    {
      return `${fieldElement} deve conter no máximo ${fieldName.errors?.maxlength.requiredLength} dígitos.`;
    }
    if (fieldName.errors?.max)
    {
      return `${fieldElement} limitada a  ${fieldName.errors?.max.max} unidades.`;
    }
    if (fieldName.errors?.email )
    {
      return `${fieldElement} inválido.`;
    }

    if (fieldElement == "Confirmar Senha")
    {

      if (fieldName.errors)
      {
        return "Confirmação de Senha inválido.";
        }
        }
  }
}
