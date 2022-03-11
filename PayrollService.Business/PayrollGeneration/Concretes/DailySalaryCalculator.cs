using PayrollService.Business.PayrollGeneration.Base;
using PayrollService.Core.PayrollDatabaseRepositories;

namespace PayrollService.Business.PayrollGeneration.Concretes
{
    public class DailySalaryCalculator : BaseSalaryCalculator
    {
        public DailySalaryCalculator(IEmployeeRepository employeeRepository,
                                       IEmployeeSalaryDetailsRepository employeeSalaryDetailsRepository,
                                       IEmployeeWorkingActivitiesRepository employeeWorkingActivitiesRepository)
             : base(employeeRepository, employeeSalaryDetailsRepository, employeeWorkingActivitiesRepository)
        {
        }

        public override double CalculateSalary(SalaryCalculationInputs salaryCalculationInputs)
        {
            return salaryCalculationInputs.DailyFee * salaryCalculationInputs.TotalWorkedDayInMonth;
        }
    }
}
