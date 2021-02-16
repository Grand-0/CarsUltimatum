using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository.CarClassRepository
{
    public class CarClassesRepository : ICarClassRepository
    {
        private readonly CarsUltimatedb _db;

        public CarClassesRepository(CarsUltimatedb db)
        {
            _db = db;
        }
        public IEnumerable<CarClass> GetAll()
        {
            return _db.CarClasses.ToList();
        }

        public CarClass GetClassByID(int id)
        {
            return _db.CarClasses.Find(id);
        }
    }
}
