using System;
using System.Collections.Generic;
using Database.Constants.Payroll;

namespace Database.Models.Payroll {
    public class PeriodicEarning : PayrollValue {
        public PeriodicEarning()
        {
            Employees = new HashSet<EmployeePeriodicEarning>();
        }
        public Period Period { get; set; }

        public ICollection<EmployeePeriodicEarning> Employees { get; set; }
    }
}