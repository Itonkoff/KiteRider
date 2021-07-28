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

            // EmployeePayroll
            CreateMap<NewEmployeePayrollDto, EmployeePayroll>();

            // Employee
            CreateMap<NewEmployeeDto, Employee>().ReverseMap();

            // Spouse
            CreateMap<NewEmployeeSpouseDto, Spouse>().ReverseMap();

            // BankingDetails
            CreateMap<NewEmployeeBankDetailDto, BankDetail>().ReverseMap();
            
            // ImmediateEarning
            CreateMap<NewEarningDeductionDto, ImmediateEarning>();
            
            // SingleFundedDeduction
            CreateMap<NewEarningDeductionDto, SingleFundedDeduction>();
            
            // PeriodicEarning
            CreateMap<NewPeriodicEarningDto, PeriodicEarning>();
            
            // ContributoryDeduction
            CreateMap<NewContributoryDeductionDto, ContributoryDeduction>();


        }
    }
}