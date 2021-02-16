using BusinessLogicLayer.ModelsDTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Company
{
    public interface ICompanyService
    {
        CompanyDTO GetCompany(int id);
        IEnumerable<CompanyDTO> GetAllCompanies();
    }
}
