namespace Dtos.Response {
    public class ContributoryDeductionDto : EarningDeductionDto {
        public double EmployeeContribution { get; set; }
        public double OrganisationContribution { get; set; }
    }
}