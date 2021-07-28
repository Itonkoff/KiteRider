using System;
using System.Collections.Generic;

namespace Database.Models.Payroll {
    public class EmployeePayroll {
        public Guid EmployeeId { get; set; }
        public Guid PayrollId { get; set; }

        public Employee Employee { get; set; }
        public Payroll Payroll { get; set; }

        public void AddToPayroll(Guid payrollId)
        {
            PayrollId = payrollId;
        }
    }
}