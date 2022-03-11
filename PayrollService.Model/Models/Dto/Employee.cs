using System.ComponentModel.DataAnnotations;
namespace PayrollService.Model.Models.Dto
{
    public class Employee : Base.Person
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeType { get; set; }
        public long IdentityNumber { get; set; }
    }
}
