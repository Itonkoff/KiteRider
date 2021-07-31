using System;
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
        public IActionResult AddImmediateEarning(Guid employeeId, [FromBody] NewImmediateEarningForEmployeeDto dto)
        {
            return BadRequest();
        }
    }
}