import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SpaceAllocationToolHttpBaseUrl } from 'src/common/constants';
import { Employee } from './model';

@Injectable()
export class EmployeeDataService {
    constructor(
        private httpClient: HttpClient
    ) { }

    getEmployeeByEmployeeId(employeeId: number): Promise<Employee> {
        const url = `${SpaceAllocationToolHttpBaseUrl}/employee/${employeeId}`;
        return this.httpClient.get<Employee>(url).toPromise();
    }

    getEmployeeByEmployeeRole(employeeRoleId: number): Promise<Employee[]> {
        const url = `${SpaceAllocationToolHttpBaseUrl}/employee-roles/${employeeRoleId}/employees`;
        return this.httpClient.get<Employee[]>(url).toPromise();
    }

    getSubordinates(employeeId: number): Promise<Employee[]> {
        const url = `${SpaceAllocationToolHttpBaseUrl}/employee/${employeeId}/subordinates`;
        return this.httpClient.get<Employee[]>(url).toPromise();
    }

    getSubordinateTeamSize(employeeId: number): Promise<number> {
        const url = `${SpaceAllocationToolHttpBaseUrl}/employee/${employeeId}/subordinate-team-size`;
        return this.httpClient.get<number>(url).toPromise();
    }
}