using System;

namespace Database.Models.Payroll {
    public class EmployeeImmediateEarning {
        public Guid EmployeeId { get; set; }
        public Guid ImmediateEarningId { get; set; }
        public double Amount { get; set; }

        public Employee Employee { get; set; }
        public ImmediateEarning Earning { get; set; }

        public void AttachEmployee(Guid employeeId) 
        {
            EmployeeId = employeeId;
        }
    }
}