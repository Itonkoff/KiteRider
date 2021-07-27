using System;
using System.Threading.Tasks;
using AutoMapper;
using Database.Contexts;
using Database.Models.Payroll;
using Dtos.Request;
using Microsoft.Extensions.Logging;

namespace Services.Api.PayrollService {
    public class PayrollService : IPayrollService {
        private readonly PayRollDatabaseContext _payRollDatabaseContext;
        private readonly ILogger<PayrollService> _logger;
        private readonly IMapper _mapper;

        public PayrollService(PayRollDatabaseContext payRollDatabaseContext, ILogger<PayrollService> logger,
            IMapper mapper)
        {
            _payRollDatabaseContext = payRollDatabaseContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<NewEmployeePayrollDto> InsertEmployee(Guid payrollId, NewEmployeePayrollDto dto)
        {
            var employee = _mapper.Map<EmployeePayroll>(dto);
            employee.PayrollId = payrollId;
            await _payRollDatabaseContext.AddAsync(employee);
            if (await _payRollDatabaseContext.SaveChangesAsync() > 0)
            {
                _logger.LogInformation("Created employee {EmployeeId}", employee.Employee.PersonId);
                return dto;
            }

            _logger.LogWarning("For some reason employee was not saved");
            return null;
        }
    }
}