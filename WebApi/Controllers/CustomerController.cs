using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private IMapper _mapper;
        public CustomerController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
