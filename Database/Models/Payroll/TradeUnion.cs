using System;

namespace Database.Models.Payroll {
    public class TradeUnion {
        public Guid TradeUnionId { get; set; }
        public string Name { get; set; }
        public bool UsePercentage { get; set; }
        public double EmployeeContribution { get; set; }
        public double OrganisationalContribution { get; set; }
    }
}