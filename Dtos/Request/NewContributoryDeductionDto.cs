namespace Dtos.Request {
    public class NewContributoryDeductionDto : NewEarningDeductionDto {
        public double EmployeeContribution { get; set; }
        public double OrganisationContribution { get; set; }
    }
}