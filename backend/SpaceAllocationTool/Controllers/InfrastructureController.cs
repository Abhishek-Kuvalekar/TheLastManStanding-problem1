using Microsoft.AspNetCore.Mvc;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Controllers {
    [Route("infra")]
    public class InfrastructureController : Controller {
        private IBuildingsRepository _buildingsRepo;
        private IFloorsRepository _floorsRepo;
        private IWingsRepository _wingsRepo;
        private IRoomsRepository _roomsRepo;
        private ISeatsRepository _seatsRepo;

        public InfrastructureController(
            IBuildingsRepository buildingsRepo,
            IFloorsRepository floorsRepo,
            IWingsRepository wingsRepo,
            IRoomsRepository roomsRepo,
            ISeatsRepository seatsRepo
        )
        {
            _buildingsRepo = buildingsRepo;
            _floorsRepo = floorsRepo;
            _wingsRepo = wingsRepo;
            _roomsRepo = roomsRepo;
            _seatsRepo = seatsRepo;
        }

        [HttpGet("buildings")]
        public IEnumerable<Building> GetBuildings() {
            return _buildingsRepo.GetBuildings();
        }

        [HttpGet("building/{buildingId}/floors")]
        public IEnumerable<Floor> GetFloors(int buildingId) {
            return _floorsRepo.GetFloors(buildingId);
        }

        [HttpGet("floor/{floorId}/wings")]
        public IEnumerable<Wing> GetWings(int floorId) {
            return _wingsRepo.GetWings(floorId);
        }

        [HttpGet("wing/{wingId}/seats")]
        public IEnumerable<Seat> GetSeats(int wingId) {
            return _seatsRepo.GetSeats(wingId);
        }

        [HttpGet("wing/{wingId}/rooms")]
        public IEnumerable<Room> GetRooms(int wingId) {
            return _roomsRepo.GetRooms(wingId);
        }
    }
}