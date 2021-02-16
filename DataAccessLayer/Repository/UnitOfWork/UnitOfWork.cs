using DataAccessLayer.DBContext;
using DataAccessLayer.Interfaces.CarRepository;
using DataAccessLayer.Repository.CarClassRepository;
using DataAccessLayer.Repository.CarRepository;
using DataAccessLayer.Repository.CompanyRepository;
using DataAccessLayer.Repository.CustomerRepository;
using DataAccessLayer.Repository.ImageRepository;
using DataAccessLayer.Repository.OrderRepository;
using System;

namespace DataAccessLayer.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarsUltimatedb _db;

        private CarsRepository _carRepository;
        private OrdersRepository _ordersRepository;
        private CarClassesRepository _carClassesRepository;
        private CompaniesRepository _companiesRepository;
        private ImagesRepository _imagesRepository;
        private CustomersRepository _customersRepository;

        public UnitOfWork(string connection)
        {
            _db = new CarsUltimatedb(connection);
        }

        public ICarRepository CarsRepository {
            get {
                if (_carRepository == null)
                    _carRepository = new CarsRepository(_db);
                return _carRepository;
            }
        }

        public IOrderRepository OrdersRepository {
            get {
                if (_ordersRepository == null)
                    _ordersRepository = new OrdersRepository(_db);
                return _ordersRepository;
            }
        }

        public ICarClassRepository CarClassesRepository 
        {
            get {
                if (_carClassesRepository == null)
                    _carClassesRepository = new CarClassesRepository(_db);
                return _carClassesRepository;
            }
        }

        public ICompanyRepository CompaniesRepository 
        {
            get {
                if (_companiesRepository == null)
                    _companiesRepository = new CompaniesRepository(_db);
                return _companiesRepository;
            }
        }

        public IImageRepository ImagesRepository 
        {
            get {
                if (_imagesRepository == null)
                    _imagesRepository = new ImagesRepository(_db);
                return _imagesRepository;
            }
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customersRepository == null)
                    _customersRepository = new CustomersRepository(_db);
                return _customersRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing) 
        {
            if (!disposed) 
            {
                if (disposing) 
                {
                    _db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
