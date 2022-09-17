using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Interfaces {
    public interface IEmployeeRolesRepository {
        public IEnumerable<EmployeeRole> GetEmployeeRoles();

        public void InitializeEmployeeRoles();
    }
}