import { EmployeeLevel, EmployeeRole, OeCode } from 'src/metadata/model';

export interface Employee {
    EmployeeId: number;
    EmployeeName: string;
    Email: string;
    OeCode: OeCode;
    Role: EmployeeRole;
    Level: EmployeeLevel;
}