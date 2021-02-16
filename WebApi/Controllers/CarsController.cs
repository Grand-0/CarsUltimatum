using AutoMapper;
using BusinessLogicLayer.Services.Car;
using WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BusinessLogicLayer.ModelsDTO;
using BusinessLogicLayer.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private ICarService _service;
        private IMapper _mapper;
        private IWebHostEnvironment _environment;
        public CarsController(ICarService carService, IMapper mapper, IWebHostEnvironment environment)
        {
            _service = carService;
            _mapper = mapper;
            _environment = environment;
        }

        // general functionality

        [HttpGet("getCar/{id}")]
        public ActionResult GetCar(int id)
        {
            Car car;
            try
            {
                car = _mapper.Map<Car>(_service.GetCar(id));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(car);
        }

        [HttpGet("getAllCars")]
        public ActionResult GetAllCars()
        {
            IEnumerable<Car> cars;
            try 
            {
                cars = _mapper.Map<IEnumerable<Car>>(_service.GetAllCars());
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(cars); 
        }

        [HttpGet("getCarsByCompany/{companyName}")]
        public ActionResult GetCarsByComapny(string comapanyName)
        {
            IEnumerable<Car> cars;
            try
            {
                cars = _mapper.Map<IEnumerable<Car>>(_service.GetCarsByCompany(comapanyName));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(cars);
        }

        [HttpGet("getCarsInClass/{className}")]
        public ActionResult GetCarsByClassName(string className)
        {
            IEnumerable<Car> cars;
            try
            {
                cars = _mapper.Map<IEnumerable<Car>>(_service.GetCarsInClass(className));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(cars);
        }

        [HttpGet("getCarsByCompanyAndClass/{companyName}/{className}")]
        public ActionResult GetCarsByCompanyAndClassName(string companyName, string className)
        {
            IEnumerable<Car> cars;
            try
            {
                cars = _mapper.Map<IEnumerable<Car>>(_service.GetCarsByClassAndCompany(className, companyName));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // administrator functionality
        [HttpPost("AddCar")]
        public ActionResult AddCar(Car car, IFormFileCollection fileCollection)
        {
            try
            {
                string defaultWebPath = _environment.WebRootPath;
                _service.AddCar(_mapper.Map<CarDTO>(car),fileCollection, defaultWebPath);
            }
            catch(RepeatException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Товар успешно добавлен");
        }

        [HttpPut("UpdateCar")]
        public ActionResult UpdateCar(Car car)
        {
            try
            {
                _service.UpdateCar(_mapper.Map<CarDTO>(car));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Характеристики товара успешно изменены");
        }

        [HttpDelete("DeleteCar")]
        public ActionResult DeleteCar(int carId)
        {
            try
            {
                string defaultWebPath = _environment.WebRootPath;
                _service.DeleteCar(carId, defaultWebPath);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Товар успешно удалён");
        }
    }
}
