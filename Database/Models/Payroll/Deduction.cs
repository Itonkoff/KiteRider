using System;

namespace Fridge.Models.Payroll {
    public class Deduction : PayrollValue {
        public Guid EmployeeId { get; set; }
        public Guid PayrollId { get; set; }
        public Guid PaySpecificationId { get; set; }

        public EmployeePayroll AssociatedPayroll { get; set; }
        
    }
}