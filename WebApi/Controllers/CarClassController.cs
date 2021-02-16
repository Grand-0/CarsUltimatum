using AutoMapper;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Services.CarClass;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarClassController : ControllerBase
    {
        private ICarClassService _service;
        private IMapper _mapper;

        public CarClassController(ICarClassService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetCarClass/{id}")]
        public ActionResult GetCarClass(int id)
        {
            CarClass carClass;

            try
            {
                carClass = _mapper.Map<CarClass>(_service.GetCarClass(id));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(carClass);
        }

        [HttpGet]
        [Route("GetAllCarClasses")]
        public ActionResult GetAllCarClasses()
        {
            return Ok(_mapper.Map<IEnumerable<CarClass>>(_service.GetAllClass()));
        }
    }
}
