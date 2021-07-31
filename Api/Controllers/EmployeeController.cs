using System;
using System.Threading.Tasks;
using Dtos.Request;
using Microsoft.AspNetCore.Mvc;
using Services.Api.Emp;

namespace Api.Controllers {
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : Controller {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("{employeeId:guid}/ie")]
        public async Task<IActionResult> AddImmediateEarning(Guid employeeId,
            [FromBody] NewEarningDeductionForEmployeeDto dto)
        {
            if (await _employeeService.InsertEmployeeImmediateEarning(employeeId, dto))
                return Ok();
            return Created("", null);
        }

        [HttpPost("{employeeId:guid}/pe")]
        public async Task<IActionResult> AddPeriodicEarning(Guid employeeId,
            [FromBody] NewEarningDeductionForEmployeeDto dto)
        {
            if (await _employeeService.InsertEmployeePeriodicEarning(employeeId, dto))
                return Ok();
            return Created("", null);
        }

        [HttpPost("{employeeId:guid}/cd")]
        public async Task<IActionResult> AddContributoryDeduction(Guid employeeId,
            [FromBody] NewEarningDeductionForEmployeeDto dto)
        {
            if (await _employeeService.InsertContributoryDeduction(employeeId, dto))
                return Ok();
            return Created("", null);
        }

        [HttpPost("{employeeId:guid}/sd")]
        public async Task<IActionResult> AddSingleFundedDeduction(Guid employeeId,
            [FromBody] NewEarningDeductionForEmployeeDto dto)
        {
            if (await _employeeService.InsertSingleFundedDeduction(employeeId, dto))
                return Ok();
            return Created("", null);
        }
    }
}