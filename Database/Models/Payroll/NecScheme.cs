using System;

namespace Fridge.Models.Payroll {
    public class NecScheme {
        public Guid NecSchemeId { get; set; }
        public string Name { get; set; }
        public bool UsePercentage { get; set; }
        public double EmployeeContribution { get; set; }
        public double OrganisationalContribution { get; set; }
    }
}