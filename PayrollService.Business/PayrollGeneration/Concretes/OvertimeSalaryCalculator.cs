using PayrollService.Business.PayrollGeneration.Base;
using PayrollService.Core.PayrollDatabaseRepositories;

namespace PayrollService.Business.PayrollGeneration.Concretes
{
    public class OvertimeSalaryCalculator : BaseSalaryCalculator
    {
        private readonly static int MIN_REQUIRED_WORKING_HOUR_IN_A_MONTH = 200;
        public OvertimeSalaryCalculator(IEmployeeRepository employeeRepository,
                                       IEmployeeSalaryDetailsRepository employeeSalaryDetailsRepository,
                                       IEmployeeWorkingActivitiesRepository employeeWorkingActivitiesRepository)
                                        : base(employeeRepository, employeeSalaryDetailsRepository, employeeWorkingActivitiesRepository)
        {

        }

        public override double CalculateSalary(SalaryCalculationInputs salaryCalculationInputs)
        {
            int overtime = salaryCalculationInputs.TotalWorkedHoursInMonth - MIN_REQUIRED_WORKING_HOUR_IN_A_MONTH;
            double grandTotal = salaryCalculationInputs.BasicSalary;

            if (overtime > 0)
            {
                grandTotal += overtime * salaryCalculationInputs.HourlyFee;
            }
            return grandTotal;
        }
    }
}
