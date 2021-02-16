using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repository.CompanyRepository
{
    public class CompaniesRepository : ICompanyRepository
    {
        private readonly CarsUltimatedb _db;
        public CompaniesRepository(CarsUltimatedb db)
        {
            _db = db;
        }

        public void Add(Company company)
        {
            _db.Companies.Add(company);
        }

        public void Delete(int id)
        {
            Company company = GetCompanyByID(id);
            if (company != null)
                _db.Companies.Remove(company);
        }

        public IEnumerable<Company> GetAll()
        {
            return _db.Companies.ToList();
        }

        public IEnumerable<Company> GetCompaniesByPredicate(Func<Company, bool> predicate)
        {
            return _db.Companies.Where(predicate).ToList();
        }

        public Company GetCompanyByID(int id)
        {
            return _db.Companies.Find(id);
        }

        public void Update(Company company)
        {
            _db.Entry(company).State = EntityState.Modified;
        }
    }
}
