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
    }
}