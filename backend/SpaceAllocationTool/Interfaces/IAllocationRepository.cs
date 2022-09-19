using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Interfaces {
    public interface IAllocationRepository {
        public IEnumerable<Seat> GetSeatsAllocatedToEmployee(int employeeId, DateTime fromDate, DateTime toDate);

        public IEnumerable<Seat> GetSeatsAllocatedToSubordinatesByEmployee(int employeeId, DateTime fromDate, DateTime toDate);

        public void SaveSeatAllocations(IEnumerable<SeatAllocation> allocations);
    }
}