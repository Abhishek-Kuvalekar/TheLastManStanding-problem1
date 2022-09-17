using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Interfaces {
    public interface IEmployeesRepository {
        public IEnumerable<Employee> GetEmployees();

        public void InitializeEmployees();
    }
}