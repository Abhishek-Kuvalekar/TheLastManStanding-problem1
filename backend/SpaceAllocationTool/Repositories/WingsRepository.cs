using SpaceAllocationTool.DbContexts;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Repositories {
    public class WingsRepository : RepositoryBase, IWingsRepository
    {
        public WingsRepository(SpaceAllocationToolContext dbContext): base(dbContext) { }

        public IEnumerable<Wing> GetWings(int floorId)
        {
            return _db.Wings
                .Where(wing => floorId <= 0 || (wing.Floor != null && wing.Floor.FloorId == floorId))
                .AsEnumerable<Wing>();
        }

        public void InitializeWings()
        {
            var lastFloor = _db.Floors.AsEnumerable().LastOrDefault();
            if (lastFloor == null) {
                return;
            }
            _db.Floors.AsEnumerable().ToList().ForEach(floor => {
                AddWing("A", 3, 40, floor);
                AddWing("B", 3, 40, floor);
                AddWing("C", 3, 40, floor);
                AddWing("D", 3, floor.FloorId == lastFloor.FloorId ? 50 : 40, floor);
            });
            _db.SaveChanges();
        }

        private void AddWing(string wingName, int totalRooms, int totalSeats, Floor floor) {
            _db.Wings.Add(new Wing
            {
                WingName = wingName, 
                TotalRooms = totalRooms,
                TotalSeats = totalSeats,
                Floor = floor
            });
        }
    }
}