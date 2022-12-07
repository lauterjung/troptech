import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export class CustomValidators {
static futureDate(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {

        const value = new Date(control.value);

        if (!value) {
            return null;
        }

        const isValid = value > new Date();

        return !isValid ? { futureDate: true } : null;
    }
}

static pastDate(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {

        const value = new Date(control.value);

        if (!value) {
            return null;
        }

        const isValid = value < new Date();

        return !isValid ? { pastDate: true } : null;
    }
}
}