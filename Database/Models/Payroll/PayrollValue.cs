using System;

namespace Database.Models.Payroll {
    public class PayrollValue {
        public Guid PayrollValueId { get; set; }
        public Guid PayrollId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }

        public EmployeePayroll AssociatedPayroll { get; set; }
    }
}