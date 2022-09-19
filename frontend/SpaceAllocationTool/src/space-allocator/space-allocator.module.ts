import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormFieldModule } from 'src/common/form-field/form-field.module';
import { InfrastructureDataServiceModule } from 'src/infrastructure-data/infrastructure-data-service.module';
import { FloorPlanComponent } from './floor-plan.component';
import { SpaceAllocatorComponent } from './space-allocator.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { MockLoginModule } from 'src/common/mock-login/mock-login.module';
import { AllocationDataModule } from 'src/allocation-data/allocation-data.module';
 
const components = [
    SpaceAllocatorComponent,
    FloorPlanComponent
]

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        BsDatepickerModule.forRoot(),
        BrowserAnimationsModule,
        InfrastructureDataServiceModule,
        AllocationDataModule,
        FormFieldModule,
        MockLoginModule
    ],
    declarations: components,
    exports: [
        SpaceAllocatorComponent
    ]
})
export class SpaceAllocatorModule { }