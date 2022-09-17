using SpaceAllocationTool.DbContexts;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Repositories {
    public class EmployeesRepository : RepositoryBase, IEmployeesRepository
    {
        public EmployeesRepository(SpaceAllocationToolContext dbContext): base(dbContext) { }

        public IEnumerable<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public void InitializeEmployees()
        {
            throw new NotImplementedException();
        }
    }
}