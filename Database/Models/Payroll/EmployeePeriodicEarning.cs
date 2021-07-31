using System;

namespace Database.Models.Payroll {
    public class EmployeePeriodicEarning {
        public Guid EmployeeId { get; set; }
        public Guid PeriodicEarningId { get; set; }
        public double Amount { get; set; }

        public Employee Employee { get; set; }
        public PeriodicEarning Earning { get; set; }

        public void AttachEmployee(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}