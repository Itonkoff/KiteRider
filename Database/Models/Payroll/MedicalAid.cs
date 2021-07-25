using System;

namespace Database.Models.Payroll {
    public class MedicalAid {
        public Guid MedicalAidSchemeId { get; set; }
        // associate with scheme
        public string MedicalAidNumber { get; set; }
        public int Children { get; set; }
        public int Dependants { get; set; }
    }
}