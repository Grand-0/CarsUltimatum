﻿using AutoMapper;
using BusinessLogicLayer.Services.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApi.Areas.Authorization.Models;
using WebApi.Options;

namespace WebApi.Areas.Authorization.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private ICustomerService _customerService;
        private IMapper _mapper;
        public AuthorizationController(ICustomerService service, IMapper mapper)
        {
            _customerService = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Authorize")]
        public ActionResult Authorize([FromForm] UserBase userBase)
        {
            var user =_mapper.Map<UserDefault>(_customerService.GetCustomer(userBase.Login, userBase.Password));

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };


                JwtSecurityToken validationToken = new JwtSecurityToken(
                    issuer: JWT_Options.ISSUER,
                    audience: JWT_Options.AUDIENCE,
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(JWT_Options.LIFETIME),
                    signingCredentials: new SigningCredentials(JWT_Options.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                    );

                var JWT = new JwtSecurityTokenHandler().WriteToken(validationToken);

                var response = new
                {
                    access_token = JWT,
                    userName = user.Login,
                    userRole = user.Role
                };

                return Ok(response);
            }

            return BadRequest("Неверный логин или пароль!");
        }

    }
}
