using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Interfaces {
    public interface IBuildingsRepository {
        public IEnumerable<Building> GetBuildings();
        
        public void InitializeBuildings();
    }
}