using System.Threading.Tasks;
using AutoMapper;
using Database.Contexts;
using Database.Models.Payroll;
using Dtos;
using Dtos.Request;
using Dtos.Response;

namespace Services.Api.Org {
    public class OrganisationService:IOrganisationService {
        private readonly PayRollDatabaseContext _payRollDatabaseContext;
        private readonly IMapper _mapper;

        public OrganisationService(PayRollDatabaseContext payRollDatabaseContext, IMapper mapper)
        {
            _payRollDatabaseContext = payRollDatabaseContext;
            _mapper = mapper;
        }

        public async Task<OrganisationDto> InsertOrganisation(NewOrganisationDto dto)
        {
            var organisation = _mapper.Map<Organisation>(dto);
            await _payRollDatabaseContext.AddAsync(organisation);
            if (await _payRollDatabaseContext.SaveChangesAsync() > 0)
            {
                return _mapper.Map<OrganisationDto>(organisation);
            }

            return null;
        }
    }
}