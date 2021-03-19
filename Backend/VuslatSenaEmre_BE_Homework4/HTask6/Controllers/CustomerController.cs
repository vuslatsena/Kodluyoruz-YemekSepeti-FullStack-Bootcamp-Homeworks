namespace HTask6.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet("[action]")]
        [ServiceFilter(typeof(IpControlAttribute))]
        public IEnumerable<string> GetCustomers()
        {
            return new List<string>
            {
             "Vuslat Sena Emre",
             "Özkan Sarıçam"
            };
        }

        [HttpGet("[action]")]
        public string GetCustomer()
        {
            return "Vuslat Sena";
        }
    }
}