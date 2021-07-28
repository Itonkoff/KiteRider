using System;
using System.Threading.Tasks;
using AutoMapper;
using Database.Contexts;
using Database.Models.Payroll;
using Dtos.Request;
using Dtos.Response;
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
            employee.AddToPayroll(payrollId);
            await _payRollDatabaseContext.AddAsync(employee);
            if (await _payRollDatabaseContext.SaveChangesAsync() > 0)
            {
                _logger.LogInformation("Created employee {EmployeeId}", employee.Employee.PersonId);
                return _mapper.Map<EmployeeDto>(employee);
            }

            _logger.LogWarning("For some reason employee was not saved");
            return null;
        }

        public async Task<EarningDeductionDto> InsertImmediateEarning(Guid payrollId, NewEarningDeductionDto dto)
        {
            var immediateEarning = _mapper.Map<ImmediateEarning>(dto);
            immediateEarning.AddToPayroll(payrollId);
            await _payRollDatabaseContext.AddAsync(immediateEarning);
            if (await _payRollDatabaseContext.SaveChangesAsync() > 0)
            {
                _logger.LogInformation("Created Immediate Earning {EarningId}", immediateEarning.PayrollValueId);
                return _mapper.Map<EarningDeductionDto>(immediateEarning);
            }

            return null;
        }

        public async Task<object> InsertSingleFinancedDeduction(Guid payrollId, NewEarningDeductionDto dto)
        {
            var singleFundedDeduction = _mapper.Map<SingleFundedDeduction>(dto);
            singleFundedDeduction.AddToPayroll(payrollId);
            await _payRollDatabaseContext.AddAsync(singleFundedDeduction);
            if (await _payRollDatabaseContext.SaveChangesAsync() > 0)
            {
                _logger.LogInformation("Created Single Financed Deduction {DeductionId}", singleFundedDeduction.PayrollValueId);
                return _mapper.Map<EarningDeductionDto>(singleFundedDeduction);
            }

            return null;
        }

        public async Task<object> InsertPeriodicEarning(Guid payrollId, NewPeriodicEarningDto dto)
        {
            var periodicEarning = _mapper.Map<PeriodicEarning>(dto);
            periodicEarning.AddToPayroll(payrollId);
            await _payRollDatabaseContext.AddAsync(periodicEarning);
            if (await _payRollDatabaseContext.SaveChangesAsync() > 0)
            {
                _logger.LogInformation("Created Periodic Earning {EarningId}", periodicEarning.PayrollValueId);
                return _mapper.Map<PeriodicEarningDto>(periodicEarning);
            }

            return null;
        }

        public async Task<object> InsertContributoryDeduction(Guid payrollId, NewContributoryDeductionDto dto)
        {
            var contributoryDeduction = _mapper.Map<ContributoryDeduction>(dto);
            contributoryDeduction.AddToPayroll(payrollId);
            await _payRollDatabaseContext.AddAsync(contributoryDeduction);
            if (await _payRollDatabaseContext.SaveChangesAsync() > 0)
            {
                _logger.LogInformation("Created Contributory Deduction {DeductionId}", contributoryDeduction.PayrollValueId);
                return _mapper.Map<ContributoryDeductionDto>(contributoryDeduction);
            }

            return null;
        }
    }
}