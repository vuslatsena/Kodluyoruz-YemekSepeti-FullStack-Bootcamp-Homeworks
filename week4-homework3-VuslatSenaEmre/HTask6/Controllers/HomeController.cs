namespace HTask6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("[action]")]
        [ServiceFilter(typeof(IpControlAttribute))]
        public IEnumerable<string> GetProducts()
        {
            return new List<string>
        {
             "pen",
             "laptop",
             "mouse"
        };
        }

        [HttpGet("[action]")]
        public string GetProduct()
        {
            return "pen";
        }
    }
}