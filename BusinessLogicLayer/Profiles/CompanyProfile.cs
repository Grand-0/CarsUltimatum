using AutoMapper;
using BusinessLogicLayer.ModelsDTO;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyDTO, Company>();
            CreateMap<Company, CompanyDTO>();
        }
    }
}
