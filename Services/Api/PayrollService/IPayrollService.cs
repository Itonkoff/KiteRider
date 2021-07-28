using System;
using System.Threading.Tasks;
using Dtos.Request;
using Dtos.Response;

namespace Services.Api.PayrollService {
    public interface IPayrollService {
        Task<NewEmployeePayrollDto> InsertEmployee(Guid payrollId, NewEmployeePayrollDto dto);
        Task<EarningDeductionDto> InsertImmediateEarning(Guid payrollId, NewEarningDeductionDto dto);
        Task<object> InsertSingleFinancedDeduction(Guid payrollId, NewEarningDeductionDto dto);
        Task<object> InsertPeriodicEarning(Guid payrollId, NewPeriodicEarningDto dto);
        Task<object> InsertContributoryDeduction(Guid payrollId, NewContributoryDeductionDto dto);
    }
}