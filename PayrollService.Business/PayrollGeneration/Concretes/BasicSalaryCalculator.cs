using PayrollService.Business.PayrollGeneration.Base;
using PayrollService.Core.PayrollDatabaseRepositories;

namespace PayrollService.Business.PayrollGeneration.Concretes
{
    public class BasicSalaryCalculator : BaseSalaryCalculator
    {

        public BasicSalaryCalculator(IEmployeeRepository employeeRepository,
                                       IEmployeeSalaryDetailsRepository employeeSalaryDetailsRepository,
                                       IEmployeeWorkingActivitiesRepository employeeWorkingActivitiesRepository)
             : base(employeeRepository, employeeSalaryDetailsRepository, employeeWorkingActivitiesRepository)
        {
        }
        public override double CalculateSalary(SalaryCalculationInputs salaryCalculationInputs)
        {
            return salaryCalculationInputs.BasicSalary;
        }
    }
}
