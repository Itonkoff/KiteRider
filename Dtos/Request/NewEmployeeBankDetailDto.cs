namespace Dtos.Request {
    public class NewEmployeeBankDetailDto {        
        public string Name { get; set; }
        public string Branch { get; set; }
        public string AccountNumber { get; set; }
        public double SplitPercentage { get; set; }
    }
}