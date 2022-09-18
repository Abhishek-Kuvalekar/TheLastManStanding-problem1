import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { InfrastructureDataService  } from './infrastructure-data.service';

@NgModule({
    imports: [
        CommonModule,
        HttpClientModule
    ],
    declarations: [],
    exports: [],
    providers: [
        InfrastructureDataService
    ]
})
export class InfrastructureDataServiceModule {}