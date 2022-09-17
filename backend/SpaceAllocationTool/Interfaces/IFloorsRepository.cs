using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Interfaces {
    public interface IFloorsRepository {
        public IEnumerable<Floor> GetFloors(int buildingId);

        public void InitializeFloors();
    }
}