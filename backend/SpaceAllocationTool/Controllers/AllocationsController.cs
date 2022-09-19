using Microsoft.AspNetCore.Mvc;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Controllers {
    [Route("allocations")]
    public class AllocationsController: Controller {
        private IAllocationRepository _allocationRepo;
        public AllocationsController(
            IAllocationRepository allocationRepo
        )
        {
            _allocationRepo = allocationRepo;            
        }

        [HttpGet("allocatee/{employeeId}")]
        public IEnumerable<Seat> GetSeatsAllocatedToEmployee(int employeeId, [FromQuery] DateTime fromDate, [FromQuery] DateTime toDate) {
            return _allocationRepo.GetSeatsAllocatedToEmployee(employeeId, fromDate, toDate);
        }

        [HttpGet("allocator/{employeeId}")]
        public IEnumerable<Seat> GetSeatsAllocatedToSubordinatesByEmployee(int employeeId, [FromQuery] DateTime fromDate, [FromQuery] DateTime toDate) {
            return _allocationRepo.GetSeatsAllocatedToSubordinatesByEmployee(employeeId, fromDate, toDate);
        }

        [HttpPost]
        public void SaveSeatAllocations(IEnumerable<SeatAllocation> allocations) {
            _allocationRepo.SaveSeatAllocations(allocations);
        }
    }
}