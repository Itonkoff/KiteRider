using System;
using System.Threading.Tasks;
using Dtos;
using Dtos.Request;
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

        [HttpPost("")]
        public async Task<IActionResult> CreateNewOrganisation([FromBody] NewOrganisationDto dto)
        {
            var organisation = await _organisationService.InsertOrganisation(dto);
            if (organisation != null)
                return Ok(organisation);
            return BadRequest();
        }
    }
}