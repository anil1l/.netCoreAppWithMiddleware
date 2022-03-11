using PayrollService.Model.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollService.Business.EmployeeServices
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int employeeId);
    }
}
