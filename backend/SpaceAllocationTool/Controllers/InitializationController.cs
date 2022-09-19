using Microsoft.AspNetCore.Mvc;
using SpaceAllocationTool.Interfaces;

namespace SpaceAllocationTool.Controllers {
    [Route("initialize")]
    public class InitializationController : Controller {
        private IDepartmentsRepository _departmentsRepo;
        private IOeCodesRepository _oeCodesRepo;
        private IEmployeeLevelsRepository _employeeLevelsRepo;
        private IEmployeeRolesRepository _employeeRolesRepo;
        private IEmployeesRepository _employeesRepo;
        private IEmployeeOrganizationsRepository _employeeOrganizationsRepo;
        private IBuildingsRepository _buildingsRepo;
        private IFloorsRepository _floorsRepo;
        private IWingsRepository _wingsRepo;
        private ISeatsRepository _seatsRepo;
        private IRoomsRepository _roomsRepo;


        public InitializationController(
            IDepartmentsRepository departmentsRepo,
            IOeCodesRepository oeCodesRepo,
            IEmployeeLevelsRepository employeeLevelsRepo,
            IEmployeeRolesRepository employeeRolesRepo,
            IEmployeesRepository employeesRepo,
            IEmployeeOrganizationsRepository employeeOrganizationsRepo,
            IBuildingsRepository buildingsRepo,
            IFloorsRepository floorsRepo,
            IWingsRepository wingsRepo,
            ISeatsRepository seatsRepo,
            IRoomsRepository roomsRepo
        )
        {
            _departmentsRepo = departmentsRepo;
            _oeCodesRepo = oeCodesRepo;
            _employeeLevelsRepo = employeeLevelsRepo;
            _employeeRolesRepo = employeeRolesRepo;
            _employeesRepo = employeesRepo;
            _employeeOrganizationsRepo = employeeOrganizationsRepo;
            _buildingsRepo = buildingsRepo;
            _floorsRepo = floorsRepo;
            _wingsRepo = wingsRepo;
            _seatsRepo = seatsRepo;
            _roomsRepo = roomsRepo;
        }

        [HttpPost("initialize")]
        public IActionResult InitializeDepartments() {
            _departmentsRepo.InitializeDepartments();
            _oeCodesRepo.InitializeOeCodes();
            _employeeLevelsRepo.InitializeEmployeeLevels();
            _employeeRolesRepo.InitializeEmployeeRoles();
            _employeesRepo.InitializeEmployees();
            // _employeeOrganizationsRepo.InitializeEmployeeOrganizations();
            _buildingsRepo.InitializeBuildings();
            _floorsRepo.InitializeFloors();
            _wingsRepo.InitializeWings();
            _seatsRepo.InitializeSeats();
            _roomsRepo.InitializeRooms();
            return Ok();
        }
    }
}