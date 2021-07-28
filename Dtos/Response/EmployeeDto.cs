using System;
using Dtos.Request;

namespace Dtos.Response {
    public class EmployeeDto : NewEmployeePayrollDto {
        public Guid EmployeeId { get; set; }
    }
}