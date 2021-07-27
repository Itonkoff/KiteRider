using System;
using System.Collections.Generic;

namespace Dtos.Request {
    public class NewEmployeeDto {
        public string Surname { get; set; }
        public string Names { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalId { get; set; }
        public string PassportNumber { get; set; }
        public int MaritalStatus { get; set; }
        public string HomeTelephone { get; set; }
        public string CellNumber { get; set; }
        public string EmailAddress { get; set; }
        public string HomeAddress { get; set; }
        public string PostalAddress { get; set; }
        public string Position { get; set; }
        public DateTime DateHired { get; set; }
        public int EmploymentStatus { get; set; }

        public List<NewEmployeeSpouseDto> Spouses { get; set; }
        public List<NewEmployeeBankDetailDto> BankDetails { get; set; }
    }
}