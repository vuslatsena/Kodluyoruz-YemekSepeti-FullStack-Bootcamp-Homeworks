namespace HTask6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("[action]")]
        public IEnumerable<string> GetCustomers()
        {
            return new List<string>
            {
             "Vuslat",
             "Özkan"
            };
        }

        [HttpGet("[action]")]
        public string GetCustomer()
        {
            return "Vuslat";
        }
    }
}