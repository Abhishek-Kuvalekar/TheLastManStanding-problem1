using SpaceAllocationTool.DbContexts;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Repositories {
    public class EmployeeLevelsRepository : RepositoryBase, IEmployeeLevelsRepository
    {
        public EmployeeLevelsRepository(SpaceAllocationToolContext dbContext): base(dbContext) { }

        public IEnumerable<EmployeeLevel> GetEmployeeLevels()
        {
            return _db.EmployeeLevels.AsEnumerable<EmployeeLevel>();
        }

        public void InitializeEmployeeLevels()
        {
            AddEmployeeLevel("Admin");
            AddEmployeeLevel("N4");
            AddEmployeeLevel("N5");
            AddEmployeeLevel("N6");
            AddEmployeeLevel("N7");
            _db.SaveChanges();
        }

        private void AddEmployeeLevel(string levelName) {
            _db.EmployeeLevels.Add(new EmployeeLevel
            {
                EmployeeLevelName = levelName
            });
        }
    }
}