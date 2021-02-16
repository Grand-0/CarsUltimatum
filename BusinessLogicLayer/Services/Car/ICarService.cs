using BusinessLogicLayer.ModelsDTO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Car
{
    public interface ICarService
    {
        void AddCar(CarDTO car, IFormFileCollection fileCollection, string defaultPath);
        void DeleteCar(int carId, string defaultPath);
        void UpdateCar(CarDTO car);
        void UpdateCar(CarDTO car, IFormFileCollection fileCollection, string defaultPath);

        CarDTO GetCar(int id);
        IEnumerable<CarDTO> GetCarsByCompany(string companyName);
        IEnumerable<CarDTO> GetCarsInClass(string className);
        IEnumerable<CarDTO> GetCarsByClassAndCompany(string className, string companyName);
        IEnumerable<CarDTO> GetAllCars();
    }
}
