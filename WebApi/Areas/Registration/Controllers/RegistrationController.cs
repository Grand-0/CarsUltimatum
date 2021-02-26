using AutoMapper;
using BusinessLogicLayer.Services.Customer;
using WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Collections.Generic;

namespace WebApi.Areas.Registration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly ICustomerService _service;
        private IMapper _mapper;
        public RegistrationController(ICustomerService customer, IMapper mapper)
        {
            _service = customer;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Registration([FromForm] Customer customer)
        {
            Customer findCustomer = _mapper.Map<Customer>(_service.GetCustomer(customer.Login, customer.Password));

            if (findCustomer != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Email, findCustomer.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, findCustomer.Role)
                };

                JwtSecurityToken validationToken = new JwtSecurityToken(
                    issuer: JWT_Options.ISSUER,
                    audience: findCustomer.Login,
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(JWT_Options.LIFETIME),
                    signingCredentials: new SigningCredentials(JWT_Options.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                    );

                var JWT = new JwtSecurityTokenHandler().WriteToken(validationToken);

                var response = new
                {
                    access_token = JWT,
                    userName = findCustomer.Login,
                    userRole = "Customer"
                };

                return Ok(response);
            }

            return BadRequest("Пользователь с данным логином уже присудствует!");
        }
    }
}
