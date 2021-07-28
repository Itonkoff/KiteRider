using System;

namespace Database.Models.Payroll {
    public class Spouse : Person {
        public Guid? EmployeeSpouseId { get; set; }

        public Employee Employee { get; set; }
    }
}