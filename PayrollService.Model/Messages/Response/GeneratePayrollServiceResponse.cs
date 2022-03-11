namespace PayrollService.Model.Messages.Response
{
    public class GeneratePayrollServiceResponse
    {
        public int EmployeeId { get; set; }
        public string EmployeeNameSurname { get; set; }
        public double GrandTotalSalary { get; set; }
        public long IdentityNumber { get; set; }

    }
}
