import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { EmployeeDataService } from 'src/employee-data/employee-data.service';
import { Employee } from 'src/employee-data/model';
import { MetadataService } from 'src/metadata/metadata.service';
import { EmployeeRole } from 'src/metadata/model';

@Component({
    selector: 'mock-login',
    templateUrl: './mock-login.component.html',
    styleUrls: ['./mock-login.component.scss'],
    host: {
        class: 'flex-row width-100p'
    }
})
export class MockLoginComponent implements OnInit {
    @Output() onUserLoggedIn: EventEmitter<Employee> = new EventEmitter<Employee>();

    employeeRoles: EmployeeRole[];
    selectedEmployeeRoleId: number;

    employees: Employee[];
    selectedEmployeeId: number;

    constructor(
        private metadataService: MetadataService,
        private employeeDataService: EmployeeDataService
    ) { }
    
    ngOnInit(): void {
        this.loadEmployeeRoles();    
    }

    onSelectEmployeeRole(employeeRoleId: number) {
        this.loadEmployees(employeeRoleId);
    }

    onSelectEmployee(employeeId: number) {
        this.onUserLoggedIn.emit(this.employees.find(e => e.EmployeeId = employeeId));
    }

    private async loadEmployeeRoles() {
        this.employeeRoles = await this.metadataService.getEmployeeRoles();
    }

    private async loadEmployees(employeeRoleId) {
        this.employees = await this.employeeDataService.getEmployeeByEmployeeRole(employeeRoleId);
    }
}