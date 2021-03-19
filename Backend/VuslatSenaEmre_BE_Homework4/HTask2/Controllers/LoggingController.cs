using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MiddlewareLog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggingController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "OKAY";
        }

        [HttpGet("Customer")]
        public Customer GetCustomer()
        {
            return new Customer()
            {
                Id = 1,
                Name = "Vuslat Sena Emre"
            };
        }

        [HttpPost("Customer ")]
        public string CreateCustomer([FromBody] Customer customer)
        {
            return "Customer Login created";
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}