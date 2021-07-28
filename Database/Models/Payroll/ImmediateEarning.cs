using System;
using System.Collections.Generic;

namespace Database.Models.Payroll {
    public class ImmediateEarning : PayrollValue {
        public ImmediateEarning()
        {
            Employees = new HashSet<EmployeeImmediateEarning>();
        }
        public ICollection<EmployeeImmediateEarning> Employees { get; set; }
    }
}