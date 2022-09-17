using SpaceAllocationTool.DbContexts;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Repositories {
    public class RoomsRepository : RepositoryBase, IRoomsRepository
    {
        public RoomsRepository(SpaceAllocationToolContext dbContext): base(dbContext) { }

        public IEnumerable<Room> GetRooms(int wingId)
        {
            return _db.Rooms
                .Where(room => wingId <= 0 || (room.Wing != null && room.Wing.WingId == wingId))
                .AsEnumerable<Room>();
        }

        public void InitializeRooms()
        {
            _db.Wings.AsEnumerable().ToList().ForEach(wing => {
                for (int i = 1; i <= 1; ++i) {
                    for (int j = 1; j <= 3; ++j) {
                        AddRoom(i, j, wing);
                    }
                }
            });
            _db.SaveChanges();
        }

        private void AddRoom(int row, int column, Wing wing) {
            _db.Rooms.Add(new Room
            {
                RowNumber = row, 
                ColumnNumber = column,
                Wing = wing
            });
        }
    }
}