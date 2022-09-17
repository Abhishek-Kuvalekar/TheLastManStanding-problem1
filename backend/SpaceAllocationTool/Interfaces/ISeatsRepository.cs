using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Interfaces {
    public interface ISeatsRepository {
        public IEnumerable<Seat> GetSeats(int wingId);

        public void InitializeSeats();
    }
}