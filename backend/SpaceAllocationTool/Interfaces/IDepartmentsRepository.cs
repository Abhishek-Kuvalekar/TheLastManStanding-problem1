using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Interfaces {
    public interface IDepartmentsRepository {
        public IEnumerable<Department> GetDepartments();

        public void InitializeDepartments();
    }
}