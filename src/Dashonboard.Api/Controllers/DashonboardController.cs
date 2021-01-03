using Dashonboard.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dashonboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashonboardController : ControllerBase
    {
        private readonly ILogger<DashonboardController> _logger;

        public DashonboardController(ILogger<DashonboardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Analyze(DashonboardRequest request)
        {
            _logger.LogInformation($"Anaylzing specified request. {request}");
            _logger.LogInformation($"Anaylsis completed.");
            return Ok("Done!");
        }
    }
}
