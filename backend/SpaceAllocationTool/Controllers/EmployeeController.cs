using Microsoft.AspNetCore.Mvc;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Controllers {
    public class EmployeeController: Controller {
        private IEmployeesRepository _employeesRepo;

        public EmployeeController(
            IEmployeesRepository employeesRepo
        )
        {
            _employeesRepo = employeesRepo;            
        }

        [HttpGet("employees")]
        public IEnumerable<Employee> GetEmployees() {
            return _employeesRepo.GetEmployees();
        }

        [HttpGet("employee/{employeeId}")]
        public Employee GetEmployee(int employeeId) {
            return _employeesRepo.GetEmployee(employeeId);
        }

        [HttpGet("employee/{employeeId}/manager")]
        public Employee GetManager(int employeeId) {
            return _employeesRepo.GetManager(employeeId);
        }

        [HttpGet("employee/{employeeId}/subordinates")]
        public IEnumerable<Employee> GetSubordinates(int employeeId) {
            return _employeesRepo.GetSubordinates(employeeId);
        }

        [HttpGet("employee/{employeeId}/subordinate-team-size")]
        public int GetSubordinateTeamSize(int employeeId) {
            return _employeesRepo.GetSubordinateTeamSize(employeeId);
        }

        [HttpGet("employee-roles/{employeeRoleId}/employees")]
        public IEnumerable<Employee> GetEmployeesByEmployeeRoleId(int employeeRoleId) {
            return _employeesRepo.GetEmployeesByEmployeeRoleId(employeeRoleId);
        }
    }
}