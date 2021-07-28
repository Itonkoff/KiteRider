namespace Database.Models.Payroll {
    public class ContributoryDeduction : PayrollValue {
        public double EmployeeContribution { get; set; }
        public double OrganisationContribution { get; set; }
        
    }
}