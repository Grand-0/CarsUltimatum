using AutoMapper;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.ModelsDTO;
using CarEntity = DataAccessLayer.Entities.Car;
using DataAccessLayer.Repository.UnitOfWork;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using ImageEntity = DataAccessLayer.Entities.Image;
using BusinessLogicLayer.Modules;
using BusinessLogicLayer.Services.Image;

namespace BusinessLogicLayer.Services.Car
{
    public class CarService : ICarService
    {
        private IUnitOfWork Database;
        private IMapper _mapper;
        private IImageService _service;

        public CarService(IUnitOfWork unitOfWork, IMapper mapper, IImageService serv)
        {
            Database = unitOfWork;
            _mapper = mapper;
            _service = serv;
        }

        public void AddCar(CarDTO car, IFormFileCollection fileCollection, string defaultWebPath)
        {
            CarDTO findCar = _mapper.Map<CarDTO>(Database.CarsRepository.GetCarsByPredicate(
                c => c.Name == car.Name && 
                c.Color == car.Color &&
                c.YearCreate == car.YearCreate)
                );

            RepeatException ex;

            if (findCar != null)
            {
                ex = new RepeatException("Данный продукт уже имеется на складе.", "Желаете ли сложить количество продуктов?", false);
                throw ex;
            }

            if (fileCollection == null)
                throw new ValidationException("Коллекция фото пуста, пожалуйста добавьте фото!", "");

            string path = defaultWebPath + @"\Images\Companies\" + findCar.CompanyName + @"\Cars\" + findCar.CarClassName + @"\" + findCar.Name;

            IEnumerable<ImageDTO> images = ImagesControl.AddImages(path, fileCollection);
            
            Database.CarsRepository.Add(_mapper.Map<CarEntity>(car));
            Database.ImagesRepository.Add(_mapper.Map<IEnumerable<ImageEntity>>(images));

            Database.Save();
        }

        public void UpdateCar(CarDTO car)
        {
            Database.CarsRepository.Update(_mapper.Map<CarEntity>(car));

            Database.Save();
        }

        public void UpdateCar(CarDTO car, IFormFileCollection fileCollection, string defaultWebPath)
        {
            string path = defaultWebPath + @"\Images\Companies\" + car.CompanyName + @"\Cars\" + car.CarClassName + @"\" + car.Name;

            IEnumerable<ImageDTO> images = ImagesControl.UpdateImages(path, fileCollection);

            Database.CarsRepository.Update(_mapper.Map<CarEntity>(car));
            Database.ImagesRepository.Update(_mapper.Map<IEnumerable<ImageEntity>>(images));

            Database.Save();
        }

        public void DeleteCar(int carId, string defaultWebPath)
        {
            CarEntity car = Database.CarsRepository.GetCarByID(carId);

            if(car != null)
            {
                Database.CarsRepository.Delete(car);

                string path = defaultWebPath + @"\Images\Companies\" + car.CompanyName + @"\Cars\" + car.CarClassName + @"\" + car.Name;
                ImagesControl.DeleteImages(path);

                Database.ImagesRepository.Delete(carId);
            }
            else
            {
                throw new ValidationException("Автомобиль с данным ключом отсутствует!", "");
            }

            Database.Save();
        }

        public CarDTO GetCar(int id)
        {
            CarDTO car = _mapper.Map<CarDTO>(Database.CarsRepository.GetCarByID(id));

            if(car == null)
            {
                throw new ValidationException("Автомобиль с данным ключом отсутствует!", "");
            }

            car.PathImages = _service.GetImagesPath(id);

            return car;
        }

        public IEnumerable<CarDTO> GetCarsByCompany(string companyName)
        {
            IEnumerable<CarDTO> cars = _mapper.Map<IEnumerable<CarDTO>>(Database.CarsRepository.GetCarsByPredicate(c => c.CompanyName == companyName));

            foreach(CarDTO car in cars)
            {
                car.PathImages = _service.GetImagesPath(car.ID);
            }

            return cars;
        }

        public IEnumerable<CarDTO> GetCarsInClass(string className)
        {
            IEnumerable<CarDTO> cars = _mapper.Map<IEnumerable<CarDTO>>(Database.CarsRepository.GetCarsByPredicate(c => c.CarClassName == className));

            foreach (CarDTO car in cars)
            {
                car.PathImages = _service.GetImagesPath(car.ID);
            }

            return cars;
        }

        public IEnumerable<CarDTO> GetCarsByClassAndCompany(string className, string companyName)
        {
            IEnumerable<CarDTO> cars = _mapper.Map<IEnumerable<CarDTO>>(Database.CarsRepository.GetCarsByPredicate(c => c.CarClassName == className && c.CompanyName == companyName));

            foreach (CarDTO car in cars)
            {
                car.PathImages = _service.GetImagesPath(car.ID);
            }

            return cars;
        }

        public IEnumerable<CarDTO> GetAllCars()
        {
            IEnumerable<CarDTO> cars = _mapper.Map<IEnumerable<CarDTO>>(Database.CarsRepository.GetCars());

            foreach (CarDTO car in cars)
            {
                car.PathImages = _service.GetImagesPath(car.ID);
            }

            return cars;
        }
    }
}
