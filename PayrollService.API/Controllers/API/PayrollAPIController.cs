using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayrollService.API.Controllers.Base;
using PayrollService.Business.PayrollGeneration;
using PayrollService.Model.Messages.Response;

namespace PayrollService.API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PayrollAPIController : BaseController
    {
        private readonly IPayrollGenerationService _payrollGenerationService;
        public PayrollAPIController(IPayrollGenerationService payrollGenerationService)
        {
            _payrollGenerationService = payrollGenerationService;
        }

        [HttpGet]
        [Route("generetaPayroll")]
        public GeneratePayrollServiceResponse GeneratePayroll([FromQuery] int employeeId)//Checkmarx Sırası
        {
            return this._payrollGenerationService.GeneratePayroll(employeeId);
        }
    }
}
