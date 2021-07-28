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
            ImmediateEarnings = new HashSet<EmployeeImmediateEarning>();
            PeriodicEarnings = new HashSet<EmployeePeriodicEarning>();
            SingleFundedDeductions = new HashSet<EmployeeSingleFundedDeduction>();
            ContributoryDeductions = new HashSet<EmployeeContributoryDeduction>();
        }

        public MaritalStatus MaritalStatus { get; set; }
        public string Position { get; set; }
        public DateTime DateHired { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }

        public ICollection<EmployeePayroll> PayRolls;
        public ICollection<Spouse> Spouses;
        public ICollection<BankDetail> BankDetails;
        public ICollection<EmployeeImmediateEarning> ImmediateEarnings { get; set; }
        public ICollection<EmployeePeriodicEarning> PeriodicEarnings { get; set; }
        public ICollection<EmployeeSingleFundedDeduction> SingleFundedDeductions { get; set; }
        public ICollection<EmployeeContributoryDeduction> ContributoryDeductions { get; set; }
    }
}