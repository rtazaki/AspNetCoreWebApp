using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApp.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
        }

        [HttpGet, Route("v1/index")]
        public IActionResult Index()
        {
            return StatusCode(200, "test");
        }
    }
}