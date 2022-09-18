import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FormFieldModule } from 'src/common/form-field/form-field.module';
import { InfrastructureDataServiceModule } from 'src/infrastructure-data/infrastructure-data-service.module';
import { FloorPlanComponent } from './floor-plan.component';
import { SpaceAllocatorComponent } from './space-allocator.component';

const components = [
    SpaceAllocatorComponent,
    FloorPlanComponent
]

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        InfrastructureDataServiceModule,
        FormFieldModule
    ],
    declarations: components,
    exports: [
        SpaceAllocatorComponent
    ]
})
export class SpaceAllocatorModule { }