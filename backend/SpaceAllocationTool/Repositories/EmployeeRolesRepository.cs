using SpaceAllocationTool.DbContexts;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Repositories {
    public class EmployeeRolesRepository : RepositoryBase, IEmployeeRolesRepository
    {
        public EmployeeRolesRepository(SpaceAllocationToolContext dbContext): base(dbContext) { }

        public IEnumerable<EmployeeRole> GetEmployeeRoles()
        {
            return _db.EmployeeRoles.AsEnumerable<EmployeeRole>();
        }

        public void InitializeEmployeeRoles()
        {
            AddEmployeeRole("Admin");
            AddEmployeeRole("Managing Director");
            AddEmployeeRole("Director");
            AddEmployeeRole("Vice Precident");
            AddEmployeeRole("Assistant Vice President");
            AddEmployeeRole("Exempt Non Officer");
            _db.SaveChanges();
        }

        private void AddEmployeeRole(string roleName) {
            _db.EmployeeRoles.Add(new EmployeeRole{
                EmployeeRoleName = roleName
            });
        }
    }
}