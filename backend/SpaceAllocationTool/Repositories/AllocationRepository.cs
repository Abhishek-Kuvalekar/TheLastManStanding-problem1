using SpaceAllocationTool.DbContexts;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Repositories {
    public class AllocationRepository : RepositoryBase, IAllocationRepository {
        public AllocationRepository(SpaceAllocationToolContext dbContext): base(dbContext) { }

        public IEnumerable<Seat> GetSeatsAllocatedToEmployee(int employeeId, DateTime fromDate, DateTime toDate)
        {
            if (employeeId == 1) {
                return _db.Seats.AsEnumerable();
            }
            return _db.SeatAllocations.Where(allocation => allocation.Date >= fromDate && allocation.Date <= toDate && allocation.Allocatee.EmployeeId == employeeId)
                .Select(allocation => allocation.Seat).AsEnumerable<Seat>();
        }

        public IEnumerable<Seat> GetSeatsAllocatedToSubordinatesByEmployee(int employeeId, DateTime fromDate, DateTime toDate)
        {
            return _db.SeatAllocations.Where(allocation => allocation.Date >= fromDate && allocation.Date <= toDate && allocation.Allocator.EmployeeId == employeeId)
                .Select(allocation => allocation.Seat).AsEnumerable<Seat>();
        }
        public void SaveSeatAllocations(IEnumerable<SeatAllocation> allocations)
        {
            _db.SeatAllocations.AddRange(allocations);
            _db.SaveChanges();
        }
    }
}