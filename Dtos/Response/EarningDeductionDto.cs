using System;
using Dtos.Request;

namespace Dtos.Response {
    public class EarningDeductionDto : NewEarningDeductionDto {
        public Guid Id { get; set; }
    }
}