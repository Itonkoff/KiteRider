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

            // PayrollDto
            CreateMap<Payroll, PayrollDto>()
                .ForMember(dest => dest.Id, op =>
                    op.MapFrom(src => src.PayrollId))
                .ForMember(dest => dest.Org, op =>
                    op.MapFrom(src => src.OrganisationId))
                .ForMember(dest => dest.PayRunDays, op =>
                    op.MapFrom(src => src.PayRunDate));
        }
    }
}