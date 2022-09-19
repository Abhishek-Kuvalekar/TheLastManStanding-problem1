namespace SpaceAllocationTool.Models {
    public class Employee {
        public int EmployeeId { get; set; }

        public string? EmployeeName { get; set; }
        
        public string? Email { get; set; }

        public virtual OeCode? OeCode { get; set; }

        public virtual EmployeeRole? Role { get; set; }

        public virtual EmployeeLevel? Level { get; set; }
    }
}