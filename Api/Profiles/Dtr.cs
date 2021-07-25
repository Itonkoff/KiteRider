using AutoMapper;
using Database.Models.Payroll;
using Dtos.Response;

namespace Api.Profiles {
    public class Dtr : Profile {
        public Dtr()
        {
            // OrganisationDto
            CreateMap<Organisation, OrganisationDto>()
                .ForMember(dest => dest.Id, op =>
                    op.MapFrom(src => src.OrganisationId));
        }
    }
}