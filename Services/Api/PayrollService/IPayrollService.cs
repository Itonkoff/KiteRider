using System;
using System.Threading.Tasks;
using Dtos.Request;

namespace Services.Api.PayrollService {
    public interface IPayrollService {
        Task<NewEmployeePayrollDto> InsertEmployee(Guid payrollId, NewEmployeePayrollDto dto);
    }
}