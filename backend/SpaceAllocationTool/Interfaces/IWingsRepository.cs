using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Interfaces {
    public interface IWingsRepository {
        public IEnumerable<Wing> GetWings(int floorId);

        public void InitializeWings();
    }
}