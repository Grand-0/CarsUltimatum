using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Repository.CompanyRepository
{
    public interface ICompanyRepository
    {
        void Add(Company company);
        void Delete(int id);
        void Update(Company company);

        Company GetCompanyByID(int id);
        IEnumerable<Company> GetAll();
        IEnumerable<Company> GetCompaniesByPredicate(Func<Company, Boolean> predicate);
    }
}
