using System;
using System.Threading.Tasks;
using AutoMapper;
using Database.Contexts;
using Database.Models.Payroll;
using Dtos.Request;

namespace Services.Api.Emp {
    public class EmployeeService : IEmployeeService {
        private readonly PayRollDatabaseContext _payRollDatabaseContext;
        private readonly IMapper _mapper;

        public EmployeeService(PayRollDatabaseContext payRollDatabaseContext, IMapper mapper)
        {
            _payRollDatabaseContext = payRollDatabaseContext;
            _mapper = mapper;
        }
        
        public async Task<bool> InsertEmployeeImmediateEarning(Guid employeeId, NewEarningDeductionForEmployeeDto dto)
        {
            var earning = _mapper.Map<EmployeeImmediateEarning>(dto);
            earning.AttachEmployee(employeeId);
            await _payRollDatabaseContext.AddAsync(earning);
            return await _payRollDatabaseContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> InsertEmployeePeriodicEarning(Guid employeeId, NewEarningDeductionForEmployeeDto dto)
        {
            var earning = _mapper.Map<EmployeePeriodicEarning>(dto);
            earning.AttachEmployee(employeeId);
            await _payRollDatabaseContext.AddAsync(earning);
            return await _payRollDatabaseContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> InsertContributoryDeduction(Guid employeeId, NewEarningDeductionForEmployeeDto dto)
        {
            var earning = _mapper.Map<EmployeeContributoryDeduction>(dto);
            earning.AttachEmployee(employeeId);
            await _payRollDatabaseContext.AddAsync(earning);
            return await _payRollDatabaseContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> InsertSingleFundedDeduction(Guid employeeId, NewEarningDeductionForEmployeeDto dto)
        {
            var earning = _mapper.Map<EmployeeSingleFundedDeduction>(dto);
            earning.AttachEmployee(employeeId);
            await _payRollDatabaseContext.AddAsync(earning);
            return await _payRollDatabaseContext.SaveChangesAsync() > 0;
        }
    }
}