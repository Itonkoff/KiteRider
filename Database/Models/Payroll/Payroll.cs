using System;
using System.Collections.Generic;
using Database.Constants.Payroll;

namespace Database.Models.Payroll {
    public class Payroll {
        public Payroll()
        {
            Employees = new HashSet<EmployeePayroll>();
        }

        public Guid PayrollId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PayRunDate { get; set; }
        public DateTime LastRunDate { get; set; }
        public PayrollStatus Status { get; set; }
        public Guid OrganisationId { get; set; }
        public bool SoftDeleted { get; set; }

        public Organisation Organisation { get; set; }
        
        public ICollection<EmployeePayroll> Employees;
    }
}