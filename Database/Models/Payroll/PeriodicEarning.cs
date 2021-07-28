using Database.Constants.Payroll;

namespace Database.Models.Payroll {
    public class PeriodicEarning : PayrollValue {        
        public Period Period { get; set; }
    }
}