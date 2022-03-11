using System.ComponentModel.DataAnnotations;

namespace PayrollService.Model.Models.Dto
{
    public class EmployeeSalaryDetails : Base.Salary
    {
        [Key]
        public int EmployeeSalaryDetailsId { get; set; }
        public int EmployeeId { get; set; }
    }
}
