using SpaceAllocationTool.DbContexts;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Repositories {
    public class OeCodesRepository : RepositoryBase, IOeCodesRepository
    {
        public OeCodesRepository(SpaceAllocationToolContext dbContext): base(dbContext) { }

        public IEnumerable<OeCode> GetOeCodes()
        {
            return _db.OeCodes.AsEnumerable<OeCode>();
        }

        public void InitializeOeCodes()
        {
            // 5 High Level Codes
            AddOeCode("Department 1", "AB", "");
            AddOeCode("Department 1", "AC", "");
            AddOeCode("Department 2", "CD", "");
            AddOeCode("Department 3", "EF", "");
            AddOeCode("Department 3", "EG", "");

            // 10 Mid Level Codes
            AddOeCode("Department 1", "ABC", "AB");
            AddOeCode("Department 1", "ABD", "AB");
            
            AddOeCode("Department 1", "ACD", "AC");
            AddOeCode("Department 1", "ACE", "AC");
            
            AddOeCode("Department 2", "CDE", "CD");
            AddOeCode("Department 2", "CDF", "CD");
            
            AddOeCode("Department 3", "EFG", "EF");
            AddOeCode("Department 3", "EFH", "EF");
            
            AddOeCode("Department 3", "EGH", "EG");
            AddOeCode("Department 3", "EGI", "EG");

            // 30 Low Level Codes
            AddOeCode("Department 1", "ABC 1", "ABC");
            AddOeCode("Department 1", "ABC 2", "ABC");
            AddOeCode("Department 1", "ABC 3", "ABC");

            AddOeCode("Department 1", "ABD 1", "ABD");
            AddOeCode("Department 1", "ABD 2", "ABD");
            AddOeCode("Department 1", "ABD 3", "ABD");

            AddOeCode("Department 1", "ACD 1", "ACD");
            AddOeCode("Department 1", "ACD 2", "ACD");
            AddOeCode("Department 1", "ACD 3", "ACD");

            AddOeCode("Department 1", "ACE 1", "ACE");
            AddOeCode("Department 1", "ACE 2", "ACE");
            AddOeCode("Department 1", "ACE 3", "ACE");

            AddOeCode("Department 2", "CDE 1", "CDE");
            AddOeCode("Department 2", "CDE 2", "CDE");
            AddOeCode("Department 2", "CDE 3", "CDE");

            AddOeCode("Department 2", "CDF 1", "CDF");
            AddOeCode("Department 2", "CDF 2", "CDF");
            AddOeCode("Department 2", "CDF 3", "CDF");

            AddOeCode("Department 3", "EFG 1", "EFG");
            AddOeCode("Department 3", "EFG 2", "EFG");
            AddOeCode("Department 3", "EFG 3", "EFG");

            AddOeCode("Department 3", "EFH 1", "EFH");
            AddOeCode("Department 3", "EFH 2", "EFH");
            AddOeCode("Department 3", "EFH 3", "EFH");

            AddOeCode("Department 3", "EGH 1", "EGH");
            AddOeCode("Department 3", "EGH 2", "EGH");
            AddOeCode("Department 3", "EGH 3", "EGH");

            AddOeCode("Department 3", "EGI 1", "EGI");
            AddOeCode("Department 3", "EGI 2", "EGI");
            AddOeCode("Department 3", "EGI 3", "EGI");
        }

        private void AddOeCode(string departmentName, string oeCode, string parentOeCodeValue) {
            var department = _db.Departments.Where(d => d.DepartmentName == departmentName).FirstOrDefault();
            var parentOeCode = _db.OeCodes.Where(o => o.OeCodeValue == parentOeCodeValue).FirstOrDefault();
            if (department == null) {
                return;
            }
            _db.OeCodes.Add(new OeCode
            {
                OeCodeValue = oeCode,
                Department = department,
                Parent = parentOeCode
            });
            _db.SaveChanges();
        }
    }
}