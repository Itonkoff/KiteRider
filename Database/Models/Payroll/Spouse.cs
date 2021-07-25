using System;

namespace Database.Models.Payroll {
    public class Spouse {
        public Guid SpouseId { get; set; }
        public string Names { get; set; }
        public string Surname { get; set; }
        public string NationalId { get; set; }
        public Guid EmployeeSpouseId { get; set; }
        
        public Employee Employee { get; set; }
    }
}