using AutoMapper;
using Database.Models.Payroll;
using Dtos;
using Dtos.Request;

namespace Api.Profiles {
    public class Rtd : Profile {
        public Rtd()
        {
            // Organisation
            CreateMap<NewOrganisationDto, Organisation>();
        }
    }
}