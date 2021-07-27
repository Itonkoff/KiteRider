using System;

namespace Dtos.Request {
    public class NewEmployeePayrollDto {
        public NewEmployeeDto Employee { get; set; }
        public NewPaySpecificationDto PaySpecification { get; set; }
    }
}