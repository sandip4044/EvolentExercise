using Evolent.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Evolent.Repository.Context
{
    public class EmployeeContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "EvolentDb");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                  .HasKey(emp => emp.Id);

            modelBuilder.Entity<Employee>()
                   .HasIndex(emp => new { emp.firstName, emp.lastName, emp.email }).IsUnique(true);

            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 1, firstName = "TestFirtName1", lastName = "TestLastName1", address = "TestAddress1", email = "test1@demo.com", age = 30 });
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 2, firstName = "TestFirtName2", lastName = "TestLastName2", address = "TestAddress2", email = "test2@demo.com", age = 28 });

            //modelBuilder.Entity<Employee>()
            //      .HasKey(emp => new { emp.firstName, emp.lastName, emp.email });
        }
    }
}
