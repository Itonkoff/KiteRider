using System;
using Dtos.Request;

namespace Dtos.Response {
    public class PayrollDto : NewPayrollDto {
        public Guid Id { get; set; }
    }
}