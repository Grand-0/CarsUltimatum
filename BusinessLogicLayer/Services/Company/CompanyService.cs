using AutoMapper;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.ModelsDTO;
using DataAccessLayer.Repository.UnitOfWork;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Company
{
    public class CompanyService : ICompanyService
    {
        private IUnitOfWork Database;
        private IMapper _mapper;
        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Database = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<CompanyDTO> GetAllCompanies()
        {
            return _mapper.Map<IEnumerable<CompanyDTO>>(Database.CompaniesRepository.GetAll());
        }

        public CompanyDTO GetCompany(int id)
        {
            CompanyDTO company = _mapper.Map<CompanyDTO>(Database.CompaniesRepository.GetCompanyByID(id));
            
            if(company == null) 
            {
                throw new ValidationException("Компании с таким ключом не существует", "");
            }

            return company;
        }
    }
}
