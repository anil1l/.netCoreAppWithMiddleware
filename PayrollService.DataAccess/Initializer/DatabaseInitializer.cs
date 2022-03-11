using PayrollService.DataAccess.Contexts;
using PayrollService.Model.Models.Dto;
using PayrollService.Model.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollService.DataAccess.Initializer
{
    public static class DatabaseInitializer
    {
        public static void Initialize(PayrollDatabaseContext context)
        {
            context.Database.EnsureCreated();
            if (context.Employee.Any())
            {
                return;
            }

            var employes = new List<Employee>();

            employes.Add(new Employee()
            {
                BirthDate = new DateTime(1991, 10, 10),
                EmployeeType = EmployeeType.BasicSalary.ToString(),
                Mail = "test",
                Name = "BASIC",
                Surname = "Test1"
            });
            employes.Add(new Employee()
            {
                BirthDate = new DateTime(1991, 10, 10),
                EmployeeType = EmployeeType.BasicSalary.ToString(),
                Mail = "test",
                Name = "BASIC",
                Surname = "Test2"
            });
            employes.Add(new Employee()
            {
                BirthDate = new DateTime(1991, 10, 10),
                EmployeeType = EmployeeType.DailySalary.ToString(),
                Mail = "test",
                Name = "DAILY",
                Surname = "Test1"
            });
            employes.Add(new Employee()
            {
                BirthDate = new DateTime(1991, 10, 10),
                EmployeeType = EmployeeType.Overtime.ToString(),
                Mail = "test",
                Name = "OVERTIME",
                Surname = "Test1"
            });

            foreach (var item in employes)
            {
                context.Employee.Add(item);
            }
            context.SaveChanges();
        }
    }
}
