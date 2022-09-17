using SpaceAllocationTool.DbContexts;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Repositories {
    public class EmployeeOrganizationsRepository : RepositoryBase, IEmployeeOrganizationsRepository
    {
        public EmployeeOrganizationsRepository(SpaceAllocationToolContext dbContext): base(dbContext) { }

        public IEnumerable<EmployeeOrganization> GetEmployeeOrganizations()
        {
            throw new NotImplementedException();
        }

        public void InitializeEmployeeOrganizations()
        {
            throw new NotImplementedException();
        }
    }
}