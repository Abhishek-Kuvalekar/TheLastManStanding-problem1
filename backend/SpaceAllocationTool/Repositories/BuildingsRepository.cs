using SpaceAllocationTool.DbContexts;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Repositories {
    public class BuildingsRepository : RepositoryBase, IBuildingsRepository
    {
        public BuildingsRepository(SpaceAllocationToolContext dbContext): base(dbContext) { }

        public IEnumerable<Building> GetBuildings()
        {
            return _db.Buildings.AsEnumerable<Building>();
        }

        public void InitializeBuildings()
        {
            AddBuilding("Building 1", 4);
            _db.SaveChanges();
        }

        private void AddBuilding(string buildingName, int totalFloors) {
            _db.Buildings.Add(new Building
            {
                BuildingName = buildingName,
                TotalFloors = totalFloors
            });
        }
    }
}