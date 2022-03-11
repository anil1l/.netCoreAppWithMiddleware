using PayrollService.Model.Messages.Response;

namespace PayrollService.Business.PayrollGeneration
{
    public interface IPayrollGenerationService
    {

        GeneratePayrollServiceResponse GeneratePayroll(int employeeId);
    }
}
