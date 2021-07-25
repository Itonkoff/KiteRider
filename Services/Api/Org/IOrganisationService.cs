using System.Threading.Tasks;
using Dtos;
using Dtos.Request;
using Dtos.Response;

namespace Services.Api.Org {
    public interface IOrganisationService {
        Task<OrganisationDto> InsertOrganisation(NewOrganisationDto dto);
        Task<PayrollDto> AddPayRollToOrganisation(NewPayrollDto dto);
    }
}