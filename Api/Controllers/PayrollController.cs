using System;
using System.Threading.Tasks;
using Dtos.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Api.PayrollService;

namespace Api.Controllers {
    [ApiController]
    [Route("api/payroll")]
    public class PayrollController : Controller {
        private readonly IPayrollService _payrollService;
        private readonly ILogger<PayrollController> _logger;

        public PayrollController(IPayrollService payrollService, ILogger<PayrollController> logger)
        {
            _payrollService = payrollService;
            _logger = logger;
        }

        [HttpPost("{payrollId:guid}/employee")]
        public async Task<IActionResult> NewEmployee(Guid payrollId, [FromBody] NewEmployeePayrollDto dto)
        {
            _logger.LogInformation("New employee");
            var newEmployeeDto = await _payrollService.InsertEmployee(payrollId, dto);
            if (newEmployeeDto != null)
                return Created("", newEmployeeDto);
            return BadRequest();
        }

        [HttpPost("{payrollId:guid}/ie")]
        public async Task<IActionResult> NewImmediateEarning(Guid payrollId, [FromBody] NewEarningDeductionDto dto)
        {
            var immediateEarning = await _payrollService.InsertImmediateEarning(payrollId, dto);
            if (immediateEarning != null)
                return Created("", immediateEarning);
            return BadRequest();
        }

        [HttpPost("{payrollId:guid}/pe")]
        public async Task<IActionResult> NewPeriodicEarning(Guid payrollId, [FromBody] NewPeriodicEarningDto dto)
        {
            var immediateEarning = await _payrollService.InsertPeriodicEarning(payrollId, dto);
            if (immediateEarning != null)
                return Created("", immediateEarning);
            return BadRequest();
        }

        [HttpPost("{payrollId:guid}/sd")]
        public async Task<IActionResult> NewSingleFinancedDeduction(Guid payrollId,
            [FromBody] NewEarningDeductionDto dto)
        {
            var immediateEarning = await _payrollService.InsertSingleFinancedDeduction(payrollId, dto);
            if (immediateEarning != null)
                return Created("", immediateEarning);
            return BadRequest();
        }

        [HttpPost("{payrollId:guid}/cd")]
        public async Task<IActionResult> NewContributoryDeduction(Guid payrollId,
            [FromBody] NewContributoryDeductionDto dto)
        {
            var immediateEarning = await _payrollService.InsertContributoryDeduction(payrollId, dto);
            if (immediateEarning != null)
                return Created("", immediateEarning);
            return BadRequest();
        }
    }
}