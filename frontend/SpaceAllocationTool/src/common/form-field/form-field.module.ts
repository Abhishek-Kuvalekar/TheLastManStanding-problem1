import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormFieldComponent } from './form-field.component';

const components = [
    FormFieldComponent
];

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: components,
    exports: components
})
export class FormFieldModule { }