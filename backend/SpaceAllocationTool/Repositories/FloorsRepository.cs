using SpaceAllocationTool.DbContexts;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Repositories {
    public class FloorsRepository : RepositoryBase, IFloorsRepository
    {
        public FloorsRepository(SpaceAllocationToolContext dbContext): base(dbContext) { }

        public IEnumerable<Floor> GetFloors(int buildingId)
        {
            return _db.Floors
                .Where(floor => buildingId <= 0 || (floor.Building != null && floor.Building.BuildingId == buildingId))
                .AsEnumerable<Floor>();
        }

        public void InitializeFloors()
        {
            AddFloor("Building 1", 4);
            AddFloor("Building 1", 4);
            AddFloor("Building 1", 4);
            AddFloor("Building 1", 4);
            _db.SaveChanges();
        }

        private void AddFloor(string buildingName, int totalWings) {
            var building = _db.Buildings.Where(b => b.BuildingName == buildingName).FirstOrDefault();
            if (building == null) {
                return;
            }
            _db.Floors.Add(new Floor {
                Building = building,
                TotalWings = totalWings
            });
        }
    }
}