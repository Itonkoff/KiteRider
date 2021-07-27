using System.Threading.Tasks;
using Dtos.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Api.Org;

namespace Api.Controllers {
    [ApiController]
    [Route("api/org")]
    public class OrganisationController : Controller {
        private readonly IOrganisationService _organisationService;
        private readonly ILogger<OrganisationController> _logger;

        public OrganisationController(IOrganisationService organisationService, ILogger<OrganisationController> logger)
        {
            _organisationService = organisationService;
            _logger = logger;
        }

        /// <summary>
        /// For Inserting a new Organisation
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> CreateNewOrganisation([FromBody] NewOrganisationDto dto)
        {
            _logger.LogInformation("New organisation =================================");
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
            _logger.LogInformation("New payroll =================================");
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