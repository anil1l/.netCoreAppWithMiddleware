using PayrollService.Model.Models.Dto;
using System.Collections.Generic;

namespace PayrollService.Model.Messages.Response
{
    public class GetAllEmployeeServiceResponse
    {
        public List<Employee> Employees { get; set; }
    }
}
