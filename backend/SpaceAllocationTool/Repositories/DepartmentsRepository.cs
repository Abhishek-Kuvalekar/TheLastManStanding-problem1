using SpaceAllocationTool.DbContexts;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Repositories {
    public class DepartmentsRepository : RepositoryBase, IDepartmentsRepository {
        public DepartmentsRepository(SpaceAllocationToolContext dbContext):base(dbContext) { }

        public IEnumerable<Department> GetDepartments()
        {
            return _db.Departments.AsEnumerable();
        }

        public void InitializeDepartments()
        {
            AddDepartment("Department 1");
            AddDepartment("Department 2");
            AddDepartment("Department 3");
            _db.SaveChanges();
        }

        private void AddDepartment(string departmentName) {
            _db.Departments.Add(new Department
            {
                DepartmentName = departmentName
            });
        }
    }
}