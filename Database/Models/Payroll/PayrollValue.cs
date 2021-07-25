using System;

namespace Database.Models.Payroll {
    public class PayrollValue {
        public Guid PayrollValueId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double EmployeeContribution { get; set; }
        public double OrganisationContribution { get; set; }
        public string Reference { get; set; }
    }
}