using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Interfaces {
    public interface IEmployeesRepository {
        public IEnumerable<Employee> GetEmployees();

        public Employee GetEmployee(int employeeId);

        public Employee GetManager(int employeeId);

        public IEnumerable<Employee> GetSubordinates(int employeeId);

        public int GetSubordinateTeamSize(int employeeId);

        public IEnumerable<Employee> GetEmployeesByEmployeeRoleId(int employeeRoleId);

        public void InitializeEmployees();
    }
}