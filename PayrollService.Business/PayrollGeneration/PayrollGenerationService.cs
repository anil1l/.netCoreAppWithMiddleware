using PayrollService.Business.PayrollGeneration.Concretes;
using PayrollService.Core.PayrollDatabaseRepositories;
using PayrollService.Model.Exceptions;
using PayrollService.Model.Messages.Response;
using PayrollService.Model.Models.Enum;

namespace PayrollService.Business.PayrollGeneration
{
    public class PayrollGenerationService : IPayrollGenerationService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly BasicSalaryCalculator _basicSalaryCalculator;
        private readonly DailySalaryCalculator _dailySalaryCalculator;
        private readonly OvertimeSalaryCalculator _overtimeSalaryCalculator;
        public PayrollGenerationService(IEmployeeRepository employeeRepository,
                                           BasicSalaryCalculator basicSalaryCalculator,
                                           DailySalaryCalculator dailySalaryCalculator,
                                           OvertimeSalaryCalculator overtimeSalaryCalculator)
        {
            _employeeRepository = employeeRepository;
            _basicSalaryCalculator = basicSalaryCalculator;
            _overtimeSalaryCalculator = overtimeSalaryCalculator;
            _dailySalaryCalculator = dailySalaryCalculator;
        }
        public GeneratePayrollServiceResponse GeneratePayroll(int employeeId)
        {
            var employee = this._employeeRepository.GetById(employeeId);

            if (employee == null)
            {
                throw new DefaultException("Employee doesnt exist!!");
            }

            double grandTotal = CalculateGrandTotal(employee);

            var response = new GeneratePayrollServiceResponse();

            response.EmployeeId = employee.EmployeeId;
            response.GrandTotalSalary = grandTotal;
            response.EmployeeNameSurname = employee.Name + " " + employee.Surname;
            response.GrandTotalSalary = grandTotal;
            response.IdentityNumber = employee.IdentityNumber;

            return response;
        }

        private double CalculateGrandTotal(Model.Models.Dto.Employee employee)
        {
            double grandTotal;

            switch (employee.EmployeeType)
            {
                case nameof(EmployeeType.BasicSalary):
                    grandTotal = this._basicSalaryCalculator.CalculateGrandTotal(employee);
                    break;
                case nameof(EmployeeType.DailySalary):
                    grandTotal = this._dailySalaryCalculator.CalculateGrandTotal(employee);
                    break;
                case nameof(EmployeeType.Overtime):
                    grandTotal = this._overtimeSalaryCalculator.CalculateGrandTotal(employee);
                    break;
                default:
                    throw new DefaultException("Unknown employee type");

            }

            return grandTotal;
        }
    }
}
