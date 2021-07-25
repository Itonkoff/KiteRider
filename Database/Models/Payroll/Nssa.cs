using System;

namespace Fridge.Models.Payroll {
    public class Nssa {
        public Guid NssaId { get; set; }
        public string Number { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}