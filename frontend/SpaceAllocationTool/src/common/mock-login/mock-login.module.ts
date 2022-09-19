import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { EmployeeDataServiceModule } from 'src/employee-data/employee-data-service.module';
import { MetadataServiceModule } from 'src/metadata/metadata-service.module';
import { FormFieldModule } from '../form-field/form-field.module';
import { MockLoginComponent } from './mock-login.component';

const components = [
    MockLoginComponent
];

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        FormFieldModule,
        MetadataServiceModule,
        EmployeeDataServiceModule
    ], 
    declarations: components,
    exports: components
})
export class MockLoginModule { }