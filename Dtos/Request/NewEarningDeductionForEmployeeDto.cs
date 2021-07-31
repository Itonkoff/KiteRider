using System;

namespace Dtos.Request {
    public class NewEarningDeductionForEmployeeDto {
        public Guid EarningDeduction { get; set; }
        public double Amount { get; set; }        
    }
}