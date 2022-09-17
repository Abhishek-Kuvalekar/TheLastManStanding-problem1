using SpaceAllocationTool.DbContexts;

namespace SpaceAllocationTool.Repositories {
    public class RepositoryBase {
        protected SpaceAllocationToolContext _db;

        public RepositoryBase(SpaceAllocationToolContext dbContext)
        {
            _db = dbContext;
        }
    }
}