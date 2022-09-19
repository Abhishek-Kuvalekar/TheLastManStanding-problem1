export interface EmployeeRole {
    EmployeeRoleId: number;
    EmployeeRoleName: string;
}

export interface EmployeeLevel {
    EmployeeLevelId: number;
    EmployeeLevelName: string;
}

export interface Department {
    DepartmentId: number;
    DepartmentName: string;
}

export interface OeCode {
    OeCodeId: number;
    OeCodeValue: string;
    Parent: OeCode;
    Department: Department;
}