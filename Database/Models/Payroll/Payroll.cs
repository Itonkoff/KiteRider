using System;
using System.Collections.Generic;
using Database.Constants.Payroll;

namespace Database.Models.Payroll {
    public class Payroll {
        public Payroll()
        {
            Employees = new HashSet<EmployeePayroll>();
            ContributoryDeductions = new HashSet<ContributoryDeduction>();
            SingleFundedDeductions = new HashSet<SingleFundedDeduction>();
            ImmediateEarnings = new HashSet<ImmediateEarning>();
            PeriodicEarnings = new HashSet<PeriodicEarning>();
        }

        public Guid PayrollId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfEmployees { get; set; }
        public int PayRunDate { get; set; }
        public DateTime? LastRunDate { get; set; }
        public PayrollStatus Status { get; set; }
        public Guid OrganisationId { get; set; }
        public bool SoftDeleted { get; set; }

        public Organisation Organisation { get; set; }
        public ICollection<ContributoryDeduction> ContributoryDeductions { get; set; }
        public ICollection<SingleFundedDeduction> SingleFundedDeductions { get; set; }
        public ICollection<ImmediateEarning> ImmediateEarnings { get; set; }
        public ICollection<PeriodicEarning> PeriodicEarnings { get; set; }

        public ICollection<EmployeePayroll> Employees;
    }
}