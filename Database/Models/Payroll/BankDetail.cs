using System;

namespace Database.Models.Payroll {
    public class BankDetail {
        public Guid BankDetailId { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string AccountNumber { get; set; }
        public double SplitPercentage { get; set; }
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}