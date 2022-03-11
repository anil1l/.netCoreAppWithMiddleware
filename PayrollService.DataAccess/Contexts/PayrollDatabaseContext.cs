using Microsoft.EntityFrameworkCore;
using PayrollService.Model.Models.Dto;

namespace PayrollService.DataAccess.Contexts
{
    public class PayrollDatabaseContext : DbContext
    {

        public PayrollDatabaseContext(DbContextOptions<PayrollDatabaseContext> options)
            : base(options)
        {


        }

        public DbSet<EmployeeWorkingActivities> EmployeeWorkingActivities { get; set; }
        public DbSet<EmployeeSalaryDetails> EmployeeSalaryDetails { get; set; }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeWorkingActivities>().ToTable("EmployeeWorkingActivity");
            modelBuilder.Entity<EmployeeSalaryDetails>().ToTable("EmployeeSalaryDetail");
            modelBuilder.Entity<Employee>().ToTable("Employee");
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
