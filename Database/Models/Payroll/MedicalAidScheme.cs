using System;
using Fridge.Constants.Payroll;

namespace Fridge.Models.Payroll {
    public class MedicalAidScheme {
        public Guid MedicalAidSchemeId { get; set; }
        public MedicalAidProviders Provider { get; set; }
        public string Title { get; set; }
    }
}