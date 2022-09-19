using Microsoft.EntityFrameworkCore;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.DbContexts {
    public class SpaceAllocationToolContext: DbContext {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OeCode> OeCodes { get; set; }
        public DbSet<EmployeeLevel> EmployeeLevels { get; set; }
        public DbSet<EmployeeOrganization> EmployeeOrganizations { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Wing> Wings { get; set; }
        public DbSet<SeatAllocation> SeatAllocations { get; set; }

        public SpaceAllocationToolContext(DbContextOptions<SpaceAllocationToolContext> options): base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Auto Increment Primary Keys
            modelBuilder.Entity<Department>().Property(e => e.DepartmentId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Employee>().Property(e => e.EmployeeId).ValueGeneratedOnAdd();
            modelBuilder.Entity<OeCode>().Property(e => e.OeCodeId).ValueGeneratedOnAdd();
            modelBuilder.Entity<EmployeeLevel>().Property(e => e.EmployeeLevelId).ValueGeneratedOnAdd();
            modelBuilder.Entity<EmployeeOrganization>().Property(e => e.EmployeeOrganizationId).ValueGeneratedOnAdd();
            modelBuilder.Entity<EmployeeRole>().Property(e => e.EmployeeRoleId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Building>().Property(e => e.BuildingId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Floor>().Property(e => e.FloorId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Room>().Property(e => e.RoomId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Seat>().Property(e => e.SeatId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Wing>().Property(e => e.WingId).ValueGeneratedOnAdd();
            modelBuilder.Entity<SeatAllocation>().Property(e => e.SeatAllocationId).ValueGeneratedOnAdd();
        }
    }
}