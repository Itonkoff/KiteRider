using System;
using System.Threading.Tasks;
using Dtos.Request;

namespace Services.Api.Emp {
    public interface IEmployeeService {
        Task<bool> InsertEmployeeImmediateEarning(Guid employeeId, NewEarningDeductionForEmployeeDto dto);
        Task<bool> InsertEmployeePeriodicEarning(Guid employeeId, NewEarningDeductionForEmployeeDto dto);
        Task<bool> InsertContributoryDeduction(Guid employeeId, NewEarningDeductionForEmployeeDto dto);
        Task<bool> InsertSingleFundedDeduction(Guid employeeId, NewEarningDeductionForEmployeeDto dto);
    }
}