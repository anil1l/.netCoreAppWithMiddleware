using System.ComponentModel.DataAnnotations;

namespace PayrollService.Model.Models.Dto
{
    public class EmployeeWorkingActivities
    {
        [Key]
        public int EmployeeWorkingActivitiesId { get; set; }
        public int EmployeeId { get; set; }
        public int WorkedMonth { get; set; }
        public int WorkedYear { get; set; }
        public int TotalWorkedDayInMonth { get; set; }
        public int TotalWorkedHoursInMonth { get; set; }
    }
}
