using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.CarRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository.CarRepository
{
    public class CarsRepository : ICarRepository
    {
        private CarsUltimatedb _db;
        public CarsRepository(CarsUltimatedb db)
        {
            _db = db;
        }

        public void Add(Car car)
        {
            _db.Cars.Add(car);
        }

        public void Delete(Car car)
        {
            _db.Cars.Remove(car);
        }

        public Car GetCarByID(int Id)
        {
            return _db.Cars.Find(Id);
        }

        public IEnumerable<Car> GetCars()
        {
            return _db.Cars.ToList();
        }

        public IEnumerable<Car> GetCarsByPredicate(Func<Car, bool> predicate)
        {
            return _db.Cars.Where(predicate).ToList();
        }

        public void Update(Car car)
        {
            _db.Entry(car).State = EntityState.Modified;
        }

        public void UpdateCount(Car car)
        {
            car.Count -= 1;
            _db.Entry(car).State = EntityState.Modified;
        }
    }
}