using System;

namespace PayrollService.Model.Models.Base
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Mail { get; set; }
    }
}
