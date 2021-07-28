using System;

namespace Database.Models.Payroll {
    public class EmployeeContributoryDeduction {
        public Guid EmployeeId { get; set; }
        public Guid ContributoryDeductionId { get; set; }
        public double Amount { get; set; }

        public Employee Employee { get; set; }
        public ContributoryDeduction Deduction { get; set; }
    }
}