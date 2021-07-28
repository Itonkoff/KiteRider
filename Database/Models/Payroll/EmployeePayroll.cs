using System;
using System.Collections.Generic;

namespace Database.Models.Payroll {
    public class EmployeePayroll {
        public EmployeePayroll()
        {
            Earnings = new HashSet<ImmediateEarning>();
            Deductions = new HashSet<ContributoryDeduction>();
        }

        public Guid EmployeeId { get; set; }
        public Guid PayrollId { get; set; }

        public Employee Employee { get; set; }
        public Payroll Payroll { get; set; }
        
        public ICollection<ImmediateEarning> Earnings;
        public ICollection<ContributoryDeduction> Deductions;
    }
}