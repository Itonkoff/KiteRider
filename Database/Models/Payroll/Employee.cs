using System;
using System.Collections.Generic;
using Database.Constants.Payroll;

namespace Database.Models.Payroll {
    public class Employee : Person {
        public Employee()
        {
            PayRolls = new HashSet<EmployeePayroll>();
            Spouses = new HashSet<Spouse>();
            BankDetails = new HashSet<BankDetail>();
        }

        public string Position { get; set; }
        public DateTime DateHired { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }

        public ICollection<EmployeePayroll> PayRolls;
        public ICollection<Spouse> Spouses;
        public ICollection<BankDetail> BankDetails;
    }
}