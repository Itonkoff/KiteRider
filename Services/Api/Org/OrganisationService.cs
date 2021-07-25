using System;
using System.Threading.Tasks;
using AutoMapper;
using Database.Contexts;
using Database.Models.Payroll;
using Dtos;
using Dtos.Request;
using Dtos.Response;
using Microsoft.AspNetCore.JsonPatch;

namespace Services.Api.Org {
    public class OrganisationService : IOrganisationService {
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

        public async Task<PayrollDto> InsertPayroll(NewPayrollDto dto)
        {
            var payroll = _mapper.Map<Payroll>(dto);
            await _payRollDatabaseContext.AddAsync(payroll);
            if (await _payRollDatabaseContext.SaveChangesAsync() > 0)
            {
                return _mapper.Map<PayrollDto>(payroll);
            }

            return null;
        }

        public async Task<bool> UpdateOrganisation(Guid organisationId,
            JsonPatchDocument<NewOrganisationDto> patchDocument)
        {
            var organisation = await _payRollDatabaseContext.Organisations.FindAsync(organisationId);
            var dto = _mapper.Map<NewOrganisationDto>(organisation);
            patchDocument.ApplyTo(dto);
            _mapper.Map(dto, organisation);
            return await _payRollDatabaseContext.SaveChangesAsync() > 0;
        }
    }
}