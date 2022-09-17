using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Interfaces {
    public interface IEmployeeOrganizationsRepository {
        public IEnumerable<EmployeeOrganization> GetEmployeeOrganizations();
        
        public void InitializeEmployeeOrganizations();
    }
}