using PayrollService.Core.PayrollDatabaseRepositories;
using PayrollService.Model.Models.Dto;
using System;

namespace PayrollService.Business.PayrollGeneration.Base
{
    public abstract class BaseSalaryCalculator
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeSalaryDetailsRepository _employeeSalaryDetailsRepository;
        private readonly IEmployeeWorkingActivitiesRepository _employeeWorkingActivitiesRepository;
        protected BaseSalaryCalculator(IEmployeeRepository employeeRepository,
                                       IEmployeeSalaryDetailsRepository employeeSalaryDetailsRepository,
                                       IEmployeeWorkingActivitiesRepository employeeWorkingActivitiesRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeSalaryDetailsRepository = employeeSalaryDetailsRepository;
            _employeeWorkingActivitiesRepository = employeeWorkingActivitiesRepository;
        }
        public abstract double CalculateSalary(SalaryCalculationInputs salaryCalculationInputs);

        public double CalculateGrandTotal(Employee employee)
        {
            var now = DateTime.Now;
            var _employeeSalaryDetails = _employeeSalaryDetailsRepository.Get(item => item.EmployeeId == employee.EmployeeId);
            var _employeeWorkingActivities = _employeeWorkingActivitiesRepository.Get(item => item.EmployeeId == employee.EmployeeId 
                                                                                              && now.Year == item.WorkedYear 
                                                                                              && now.Month == item.WorkedMonth);
            if (_employeeWorkingActivities == null || _employeeSalaryDetails == null)
            {
                return 0;
            }

            var salaryCalculationInputs = new SalaryCalculationInputs();
            salaryCalculationInputs.BasicSalary = _employeeSalaryDetails.BasicSalary;
            salaryCalculationInputs.HourlyFee = _employeeSalaryDetails.HourlyFee;
            salaryCalculationInputs.DailyFee = _employeeSalaryDetails.DailyFee;
            salaryCalculationInputs.TotalWorkedDayInMonth = _employeeWorkingActivities.TotalWorkedDayInMonth;
            salaryCalculationInputs.TotalWorkedHoursInMonth = _employeeWorkingActivities.TotalWorkedHoursInMonth;

            return CalculateSalary(salaryCalculationInputs);
        }
    }

    public class SalaryCalculationInputs
    {
        public double BasicSalary { get; set; }
        public double HourlyFee { get; set; }
        public double DailyFee { get; set; }
        public int TotalWorkedDayInMonth { get; set; }
        public int TotalWorkedHoursInMonth { get; set; }
    }
}
