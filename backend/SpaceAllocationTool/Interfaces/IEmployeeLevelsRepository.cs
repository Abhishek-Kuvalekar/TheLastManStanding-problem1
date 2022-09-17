using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Interfaces {
    public interface IEmployeeLevelsRepository {
        public IEnumerable<EmployeeLevel> GetEmployeeLevels();

        public void InitializeEmployeeLevels();
    }
}