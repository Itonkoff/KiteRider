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
            
            // EmployeeDto
            CreateMap<EmployeePayroll, EmployeeDto>();
            
            // EarningDeductionDto => ImmediateEarning
            CreateMap<ImmediateEarning, EarningDeductionDto>()
                .ForMember(dest=>dest.Id, op=>
                    op.MapFrom(src=>src.PayrollValueId));
            
            // SingleFundedDeductionDto
            CreateMap<SingleFundedDeduction, EarningDeductionDto>()
                .ForMember(dest=>dest.Id, op=>
                    op.MapFrom(src=>src.PayrollValueId));
                        
            // ContributoryDeductionDto
            CreateMap<ContributoryDeduction, ContributoryDeductionDto>()
                .ForMember(dest=>dest.Id, op=>
                    op.MapFrom(src=>src.PayrollValueId));
            
            // PeriodicEarningDto
            CreateMap<PeriodicEarning, PeriodicEarningDto>()
                .ForMember(dest=>dest.Id, op=>
                    op.MapFrom(src=>src.PayrollValueId));
        }
    }
}