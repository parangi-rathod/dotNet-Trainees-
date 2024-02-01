using DI.Service;// ValuesController.cs
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IMyService _myService;

        // Constructor Injection
        public HomeController(IMyService myService)
        {
            _myService = myService;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            string message = _myService.Greet();
            return Ok(message);
        }
    }
}

