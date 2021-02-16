using AutoMapper;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Services.Company;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private ICompanyService _service;
        private IMapper _mapper;
        public CompaniesController(ICompanyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("GetAllCompanies")]
        public ActionResult GetAllCompanies()
        {
            return Ok(_mapper.Map<IEnumerable<Company>>(_service.GetAllCompanies()));
        }

        [HttpGet("GetCompany/{id}")]
        public ActionResult GetCompanyById(int id)
        {
            Company company;

            try
            {
                company = _mapper.Map<Company>(_service.GetCompany(id));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(company);
        }
    }
}
