using System;
using System.Threading.Tasks;
using Dtos;
using Dtos.Request;
using Dtos.Response;
using Microsoft.AspNetCore.JsonPatch;

namespace Services.Api.Org {
    public interface IOrganisationService {
        Task<OrganisationDto> InsertOrganisation(NewOrganisationDto dto);
        Task<PayrollDto> InsertPayroll(NewPayrollDto dto);
        Task<bool> UpdateOrganisation(Guid organisationId, JsonPatchDocument<NewOrganisationDto> patchDocument);
    }
}