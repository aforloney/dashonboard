using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dashonboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Analyze()
        {
            return Ok("Done!");
        }
    }
}
