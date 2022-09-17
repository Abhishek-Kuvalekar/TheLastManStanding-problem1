using Microsoft.AspNetCore.Mvc;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Controllers {
    [Route("metadata")]
    public class MetaDataController : Controller {
        private IDepartmentsRepository _departmentRepo;
        private IOeCodesRepository _oeCodesRepo;
        private IEmployeeLevelsRepository _employeeLevelsRepo;
        private IEmployeeRolesRepository _employeeRolesRepo;

        public MetaDataController(
            IDepartmentsRepository departmentRepo,
            IOeCodesRepository oeCodesRepo,
            IEmployeeLevelsRepository employeeLevelsRepo,
            IEmployeeRolesRepository employeeRolesRepo
        )
        {
            _departmentRepo = departmentRepo;
            _oeCodesRepo = oeCodesRepo;
            _employeeLevelsRepo = employeeLevelsRepo;
            _employeeRolesRepo = employeeRolesRepo;            
        }

        [HttpGet("departments")]
        public IEnumerable<Department> GetDepartments() {
            return _departmentRepo.GetDepartments();
        }

        [HttpGet("oe-codes")]
        public IEnumerable<OeCode> GetOeCodes() {
            return _oeCodesRepo.GetOeCodes();
        }

        [HttpGet("employee-levels")]
        public IEnumerable<EmployeeLevel> GetEmployeeLevels() {
            return _employeeLevelsRepo.GetEmployeeLevels();
        }

        [HttpGet("employee-roles")]
        public IEnumerable<EmployeeRole> GetEmployeeRoles() {
            return _employeeRolesRepo.GetEmployeeRoles();
        }
    }
}