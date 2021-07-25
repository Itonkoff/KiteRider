using System;

namespace Fridge.Models.Payroll {
    public class TaxParameter {
        public Guid TaxParameterId { get; set; }
        public bool TaxDirective { get; set; }
        public double? Percentage { get; set; }
        public bool BlindPerson { get; set; }
        public bool DisabledPerson { get; set; }
        public bool Dependants { get; set; }        
    }
}