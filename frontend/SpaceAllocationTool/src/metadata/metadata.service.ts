import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SpaceAllocationToolHttpBaseUrl } from 'src/common/constants';
import { EmployeeRole } from './model';

@Injectable()
export class MetadataService {
    constructor(
        private httpClient: HttpClient
    ) { }

    getEmployeeRoles(): Promise<EmployeeRole[]> {
        const url = `${SpaceAllocationToolHttpBaseUrl}/metadata/employee-roles`;
        return this.httpClient.get<EmployeeRole[]>(url).toPromise();
    }
}