using PayrollService.Core.PayrollDatabaseRepositories;
using PayrollService.Model.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollService.Business.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeSalaryDetailsRepository _employeeSalaryDetailsRepository;
        private readonly IEmployeeWorkingActivitiesRepository _employeeWorkingActivitiesRepository;
        public EmployeeService(IEmployeeRepository employeeRepository,
                                       IEmployeeSalaryDetailsRepository employeeSalaryDetailsRepository,
                                       IEmployeeWorkingActivitiesRepository employeeWorkingActivitiesRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeSalaryDetailsRepository = employeeSalaryDetailsRepository;
            _employeeWorkingActivitiesRepository = employeeWorkingActivitiesRepository;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return this._employeeRepository.GetById(employeeId);
        }

        public List<Employee> GetEmployees()
        {
            return this._employeeRepository.GetAll().ToList();
        }
    }
}
