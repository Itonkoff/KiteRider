using System;

namespace Dtos.Request {
    public class NewEmployeeSpouseDto {  
        public string Surname { get; set; }
        public string Names { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalId { get; set; }
        public string PassportNumber { get; set; }
        public string HomeTelephone { get; set; }
        public string CellNumber { get; set; }
        public string EmailAddress { get; set; }
        public string HomeAddress { get; set; }
        public string PostalAddress { get; set; }
    }
}