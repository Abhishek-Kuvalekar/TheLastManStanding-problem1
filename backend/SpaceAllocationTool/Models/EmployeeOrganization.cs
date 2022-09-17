namespace SpaceAllocationTool.Models {
    public class EmployeeOrganization {
        public int EmployeeOrganizationId { get; set; }

        public virtual Employee? Employee { get; set; }

        public virtual Employee? Manager { get; set; }
    }
}