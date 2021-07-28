using System;
using System.Collections.Generic;

namespace Database.Models.Payroll {
    public class SingleFundedDeduction : PayrollValue {
        public SingleFundedDeduction()
        {
            Employees = new HashSet<EmployeeSingleFundedDeduction>();
        }
        public ICollection<EmployeeSingleFundedDeduction> Employees { get; set; }
    }
}