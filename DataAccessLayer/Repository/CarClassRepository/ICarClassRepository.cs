using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.Repository.CarClassRepository
{
    public interface ICarClassRepository
    {
        IEnumerable<CarClass> GetAll();
        CarClass GetClassByID(int id);
    }
}