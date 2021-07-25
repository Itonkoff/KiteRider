using System;
using System.Collections.Generic;

namespace Database.Models.Payroll {
    public class EmployeePayroll {
        public EmployeePayroll()
        {
            Earnings = new HashSet<Earning>();
            Deductions = new HashSet<Deduction>();
        }

        public Guid EmployeeId { get; set; }
        public Guid PayrollId { get; set; }
        public Guid PaySpecificationId { get; set; }

        public Employee Employee { get; set; }
        public Payroll Payroll { get; set; }
        public PaySpecification PaySpecification { get; set; }
        
        public ICollection<Earning> Earnings;
        public ICollection<Deduction> Deductions;
    }
}