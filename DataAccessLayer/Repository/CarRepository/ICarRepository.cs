using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces.CarRepository
{
    public interface ICarRepository
    {
        Car GetCarByID(int Id);
        IEnumerable<Car> GetCars();
        IEnumerable<Car> GetCarsByPredicate(Func<Car, Boolean> predicate);

        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}
