using DataAccessLayer.Interfaces.CarRepository;
using DataAccessLayer.Repository.CarClassRepository;
using DataAccessLayer.Repository.CompanyRepository;
using DataAccessLayer.Repository.CustomerRepository;
using DataAccessLayer.Repository.ImageRepository;
using DataAccessLayer.Repository.OrderRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository CarsRepository { get; } 
        IOrderRepository OrdersRepository { get; }
        ICarClassRepository CarClassesRepository { get; }
        IImageRepository ImagesRepository { get; }
        ICompanyRepository CompaniesRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        void Save();
    }
}
