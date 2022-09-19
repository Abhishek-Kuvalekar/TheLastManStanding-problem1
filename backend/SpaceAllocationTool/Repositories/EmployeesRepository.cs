using SpaceAllocationTool.DbContexts;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Repositories {
    public class EmployeesRepository : RepositoryBase, IEmployeesRepository
    {
        public EmployeesRepository(SpaceAllocationToolContext dbContext): base(dbContext) { }

        public IEnumerable<Employee> GetEmployees()
        {
            return _db.Employees.AsEnumerable<Employee>();
        }

        public Employee GetEmployee(int employeeId) {
            return _db.Employees.Where(e => e.EmployeeId == employeeId).FirstOrDefault();
        }

        public Employee GetManager(int employeeId) {
            return _db.EmployeeOrganizations.Where(o => o.Employee.EmployeeId == employeeId).Select(o => o.Manager).FirstOrDefault();
        }

        public IEnumerable<Employee> GetSubordinates(int employeeId) {
            var employee = _db.Employees.Where(e => e.EmployeeId == employeeId).FirstOrDefault();
            if (employee == null) {
                return new List<Employee>();
            }
            return _db.EmployeeOrganizations.Where(o => o.Manager.EmployeeId == employeeId).Select(o => o.Employee).AsEnumerable().Append(employee);
        }

        public int GetSubordinateTeamSize(int employeeId) {
            int teamSize = 0;
            var subordinates = new List<int>();
            subordinates.Add(employeeId);
            while (subordinates.Count > 0) {
                int id = subordinates.ElementAt(0);
                ++teamSize;
                subordinates.RemoveAt(0);
                var directSubordinates = _db.EmployeeOrganizations.Where(o => o.Manager.EmployeeId == id).Select(o => o.Employee.EmployeeId).Distinct();
                subordinates.AddRange(directSubordinates);
            }
            return teamSize;
        }

        public IEnumerable<Employee> GetEmployeesByEmployeeRoleId(int employeeRoleId) {
            return _db.Employees.Where(e => e.Role.EmployeeRoleId == employeeRoleId).AsEnumerable();
        }

        public void InitializeEmployees()
        {
            var oeCodes = _db.OeCodes.AsEnumerable<OeCode>();
            var employeeRoles = _db.EmployeeRoles.AsEnumerable<EmployeeRole>();
            var employeeLevels = _db.EmployeeLevels.AsEnumerable<EmployeeLevel>();

            var admin = employeeLevels.Where(l => l.EmployeeLevelName == "Admin").FirstOrDefault();
            var ad = employeeRoles.Where(r => r.EmployeeRoleName == "Admin").FirstOrDefault();
            _db.Employees.Add(GetEmployee($"Admin", "admin@email.com", null, ad, admin));
            _db.SaveChanges();

            var n4 = employeeLevels.Where(l => l.EmployeeLevelName == "N4").FirstOrDefault();
            var mdr = employeeRoles.Where(r => r.EmployeeRoleName == "Managing Director").FirstOrDefault();
            var admin1 = _db.Employees.Where(e => e.EmployeeName == "Admin").FirstOrDefault();
            oeCodes.Where(code => code.OeCodeValue?.Length == 2).ToList().ForEach(code => {
                var e = GetEmployee($"MDR {code.OeCodeValue}", $"mdr-{code.OeCodeValue}@email.com", code, mdr, n4);
                _db.Employees.Add(e);
                AddEmployeeOrganization(e, admin1);
            });
            _db.SaveChanges();

            var n5 = employeeLevels.Where(l => l.EmployeeLevelName == "N5").FirstOrDefault();
            var dir = employeeRoles.Where(r => r.EmployeeRoleName == "Director").FirstOrDefault();
            _db.Employees.Where(e => e.Role.EmployeeRoleName == "Managing Director").AsEnumerable().ToList().ForEach(mdr => {
                var codes = _db.OeCodes.Where(c => c.OeCodeValue.StartsWith(mdr.OeCode.OeCodeValue) && c.OeCodeValue.Length == 3).AsEnumerable().ToArray();
                
                var e1 = GetEmployee($"DIR {codes[0].OeCodeValue} 1", $"dir-{codes[0].OeCodeValue}-1@email.com", codes[0], dir, n5);
                _db.Employees.Add(e1);
                AddEmployeeOrganization(e1, mdr);
                
                e1 = GetEmployee($"DIR {codes[1].OeCodeValue} 1", $"dir-{codes[1].OeCodeValue}-1@email.com", codes[1], dir, n5);
                _db.Employees.Add(e1);
                AddEmployeeOrganization(e1, mdr);
                
                e1 = GetEmployee($"DIR {codes[0].OeCodeValue} 2", $"dir-{codes[0].OeCodeValue}-2@email.com", codes[0], dir, n5);
                _db.Employees.Add(e1);
                AddEmployeeOrganization(e1, mdr);
            });
            _db.SaveChanges();

            var n6 = employeeLevels.Where(l => l.EmployeeLevelName == "N6").FirstOrDefault();
            var vp = employeeRoles.Where(r => r.EmployeeRoleName == "Vice President").FirstOrDefault();
            _db.Employees.Where(e => e.Role.EmployeeRoleName == "Director").AsEnumerable().ToList().ForEach(dir => {
                var codes = _db.OeCodes.Where(c => c.OeCodeValue.StartsWith(dir.OeCode.OeCodeValue) && c.OeCodeValue.Length > 3).AsEnumerable().ToArray();
                
                var e1 = GetEmployee($"VP {codes[0].OeCodeValue} 1", $"vp-{codes[0].OeCodeValue}-1@email.com", codes[0], vp, n6);
                _db.Employees.Add(e1);
                AddEmployeeOrganization(e1, dir);

                e1 = GetEmployee($"VP {codes[1].OeCodeValue} 1", $"vp-{codes[1].OeCodeValue}-1@email.com", codes[1], vp, n6);
                _db.Employees.Add(e1);
                AddEmployeeOrganization(e1, dir);

                e1 = GetEmployee($"VP {codes[2].OeCodeValue} 1", $"vp-{codes[2].OeCodeValue}-1@email.com", codes[2], vp, n6);
                _db.Employees.Add(e1);
                AddEmployeeOrganization(e1, dir);

                e1 = GetEmployee($"VP {codes[0].OeCodeValue} 2", $"vp-{codes[0].OeCodeValue}-2@email.com", codes[0], vp, n6);
                _db.Employees.Add(e1);
                AddEmployeeOrganization(e1, dir);

                e1 = GetEmployee($"VP {codes[1].OeCodeValue} 2", $"vp-{codes[1].OeCodeValue}-2@email.com", codes[1], vp, n6);
                _db.Employees.Add(e1);
                AddEmployeeOrganization(e1, dir);
            });
            _db.SaveChanges();

            var n7 = employeeLevels.Where(l => l.EmployeeLevelName == "N7").FirstOrDefault();
            var avp = employeeRoles.Where(r => r.EmployeeRoleName == "Assistant Vice President").FirstOrDefault();
            _db.Employees.Where(e => e.Role.EmployeeRoleName == "Vice President").AsEnumerable().ToList().ForEach(vp => {
                var e1 = GetEmployee($"AVP {vp.OeCode.OeCodeValue} 1", $"avp-{vp.OeCode.OeCodeValue}-1@email.com", vp.OeCode, avp, n7);
                _db.Employees.Add(e1);
                AddEmployeeOrganization(e1, vp);

                e1 = GetEmployee($"AVP {vp.OeCode.OeCodeValue} 2", $"avp-{vp.OeCode.OeCodeValue}-2@email.com", vp.OeCode, avp, n7);
                _db.Employees.Add(e1);
                AddEmployeeOrganization(e1, vp);

                e1 = GetEmployee($"AVP {vp.OeCode.OeCodeValue} 3", $"avp-{vp.OeCode.OeCodeValue}-3@email.com", vp.OeCode, avp, n7);
                _db.Employees.Add(e1);
                AddEmployeeOrganization(e1, vp);
            });
            _db.SaveChanges();

            n7 = employeeLevels.Where(l => l.EmployeeLevelName == "N7").FirstOrDefault();
            var eno = employeeRoles.Where(r => r.EmployeeRoleName == "Exempt Non Officer").FirstOrDefault();
            _db.Employees.Where(e => e.Role.EmployeeRoleName == "Assistant Vice President").AsEnumerable().ToList().ForEach(avp => {
                var e1 = GetEmployee($"ENO {avp.OeCode.OeCodeValue} 1", $"eno-{avp.OeCode.OeCodeValue}-1@email.com", avp.OeCode, eno, n7);
                _db.Employees.Add(e1);
                AddEmployeeOrganization(e1, avp);

                e1 = GetEmployee($"ENO {avp.OeCode.OeCodeValue} 2", $"eno-{avp.OeCode.OeCodeValue}-2@email.com", avp.OeCode, eno, n7);
                _db.Employees.Add(e1);
                AddEmployeeOrganization(e1, avp);

                e1 = GetEmployee($"ENO {avp.OeCode.OeCodeValue} 3", $"eno-{avp.OeCode.OeCodeValue}-3@email.com", avp.OeCode, eno, n7);
                _db.Employees.Add(e1);
                AddEmployeeOrganization(e1, avp);
            });
            _db.SaveChanges();

        }

        private Employee GetEmployee(
            string employeeName, 
            string email,
            OeCode oeCode,
            EmployeeRole employeeRole,
            EmployeeLevel employeeLevel
        ) {
            return new Employee
            {
                EmployeeName = employeeName,
                Email = email,
                OeCode = oeCode,
                Level = employeeLevel,
                Role = employeeRole
            };            
        }

        private void AddEmployeeOrganization(
            Employee employee, 
            Employee manager
        ) {
            _db.EmployeeOrganizations.Add(new EmployeeOrganization {
                Employee = employee,
                Manager = manager
            });
        }
    }
}