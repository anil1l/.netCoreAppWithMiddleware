using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PayrollService.API.Controllers.Base;
using PayrollService.Business.EmployeeServices;
using PayrollService.Business.PayrollGeneration;
using PayrollService.Model.Messages.Response;
using System;

namespace PayrollService.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[EnableCors("MyPolicy")]

    //[Authorize] =>Authorization necessary for internall calls.
    public class PayrollServiceController : BaseController
    {
        private readonly IPayrollGenerationService _payrollGenerationService;
        private readonly IEmployeeService _employeeService;
        public PayrollServiceController(IPayrollGenerationService payrollGenerationService, IEmployeeService employeeService)
        {
            _payrollGenerationService = payrollGenerationService;
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("generetaPayroll")]

        public GeneratePayrollServiceResponse GeneratePayroll([FromQuery] int employeeId)
        {
            
            return this._payrollGenerationService.GeneratePayroll(employeeId);
        }


        [HttpGet]
        [Route("getAllEmployees")]

        public GetAllEmployeeServiceResponse GetAllEmployees()
        {
            return new GetAllEmployeeServiceResponse()
            {
                Employees = this._employeeService.GetEmployees()
            };

        }

        [HttpGet]
        [Route("getEmployeeById")]
        public GetEmployeeByIdServiceReponse GetEmployeeById([FromQuery] int employeeId)
        {
            return new GetEmployeeByIdServiceReponse()
            {
                Employee = this._employeeService.GetEmployeeById(employeeId)
            };
        }
    }
}
