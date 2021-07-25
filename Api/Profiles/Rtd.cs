using AutoMapper;
using Database.Models.Payroll;
using Dtos;
using Dtos.Request;

namespace Api.Profiles {
    public class Rtd : Profile {
        public Rtd()
        {
            // Organisation
            CreateMap<NewOrganisationDto, Organisation>().ReverseMap();

            // Payroll
            CreateMap<NewPayrollDto, Payroll>()
                .ForMember(dest => dest.OrganisationId, op =>
                    op.MapFrom(src => src.Org))
                .ForMember(dest => dest.PayRunDate, op =>
                    op.MapFrom(src => src.PayRunDays));
        }
    }
}