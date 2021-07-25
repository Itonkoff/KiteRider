using System;

namespace Dtos.Request {
    public class NewPayrollDto {
        public Guid Org { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PayRunDays { get; set; }
    }
}