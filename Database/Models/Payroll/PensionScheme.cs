using System;
using Fridge.Constants.Payroll;

namespace Fridge.Models.Payroll {
    public class PensionScheme {
        public int PensionSchemeId { get; set; }
        public PensionSchemes Name { get; set; }
        public string Reference { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}