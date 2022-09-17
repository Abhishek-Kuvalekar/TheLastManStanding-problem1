using Microsoft.EntityFrameworkCore;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.DbContexts {
    public class SpaceAllocationToolContext: DbContext {
        public DbSet<Employee> employees { get; set; }
        public DbSet<OeCode> oeCodes { get; set; }
        public DbSet<EmployeeLevel> employeeLevels { get; set; }
        public DbSet<EmployeeOrganization> employeeOrganizations { get; set; }
        public DbSet<EmployeeRole> employeeRoles { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<Floor> floors { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Seat> seats { get; set; }
        public DbSet<Wing> wings { get; set; }

        public SpaceAllocationToolContext(DbContextOptions<SpaceAllocationToolContext> options): base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Auto Increment of Primary Keys
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
        }
    }
}