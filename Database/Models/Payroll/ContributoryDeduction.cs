using System.Collections.Generic;

namespace Database.Models.Payroll {
    public class ContributoryDeduction : PayrollValue {
        public ContributoryDeduction()
        {
            Employees = new HashSet<EmployeeContributoryDeduction>();
        }
        public double EmployeeContribution { get; set; }
        public double OrganisationContribution { get; set; }

        public ICollection<EmployeeContributoryDeduction> Employees { get; set; }
        
    }
}