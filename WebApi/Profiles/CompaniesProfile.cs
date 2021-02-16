using AutoMapper;
using BusinessLogicLayer.ModelsDTO;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class CompaniesProfile : Profile
    {
        public CompaniesProfile()
        {
            CreateMap<CompanyDTO, Company>();
            CreateMap<Company, CompanyDTO>();
        }
    }
}
