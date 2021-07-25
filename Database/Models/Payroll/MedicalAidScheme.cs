using System;
using Database.Constants.Payroll;

namespace Database.Models.Payroll {
    public class MedicalAidScheme {
        public Guid MedicalAidSchemeId { get; set; }
        public MedicalAidProviders Provider { get; set; }
        public string Title { get; set; }
    }
}