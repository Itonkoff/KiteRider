using System;
using System.Threading.Tasks;
using Dtos;
using Dtos.Request;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Api.Org;

namespace Api.Controllers {
    [ApiController]
    [Route("api/org")]
    public class OrganisationController : Controller {
        private readonly IOrganisationService _organisationService;

        public OrganisationController(IOrganisationService organisationService)
        {
            _organisationService = organisationService;
        }

        /// <summary>
        /// For Inserting a new Organisation
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> CreateNewOrganisation([FromBody] NewOrganisationDto dto)
        {
            var organisation = await _organisationService.InsertOrganisation(dto);
            if (organisation != null)
                return Ok(organisation);
            return BadRequest();
        }

        /// <summary>
        /// For adding a payroll to an organisation
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("payroll")]
        public async Task<IActionResult> AddNewPayroll([FromBody] NewPayrollDto dto)
        {
            var payroll = await _organisationService.InsertPayroll(dto);
            if (payroll != null)
                return Ok(payroll);
            return BadRequest();
        }

        // [HttpPatch("{organisationId:guid}")]
        // public async Task<IActionResult> UpdateOrganisation(Guid organisationId,
        //     [FromBody] JsonPatchDocument<NewOrganisationDto> patchDocument)
        // {
        //     if (await _organisationService.UpdateOrganisation(organisationId, patchDocument))
        //         return Ok();
        //     return BadRequest();
        // }
    }
}