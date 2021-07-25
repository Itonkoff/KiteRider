using System;
using Fridge.Constants.Payroll;

namespace Fridge.Models.Payroll {
    public class PaySpecification {
        public Guid PaySpecificationId { get; set; }
        public Period Period { get; set; }
        public double BaseAmount { get; set; }

        public EmployeePayroll Payroll { get; set; }
        // TODO: deal with leave
    }
}