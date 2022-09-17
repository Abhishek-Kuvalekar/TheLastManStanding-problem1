using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Interfaces {
    public interface IRoomsRepository {
        public IEnumerable<Room> GetRooms(int wingId);

        public void InitializeRooms();
    }
}