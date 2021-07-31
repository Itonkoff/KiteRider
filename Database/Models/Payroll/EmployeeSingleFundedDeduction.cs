using System;

namespace Database.Models.Payroll {
    public class EmployeeSingleFundedDeduction {
        public Guid EmployeeId { get; set; }
        public Guid SingleFundedDeductionId { get; set; }
        public double Amount { get; set; }

        public Employee Employee { get; set; }
        public SingleFundedDeduction Deduction { get; set; }

        public void AttachEmployee(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}