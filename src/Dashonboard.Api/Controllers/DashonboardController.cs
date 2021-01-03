using Dashonboard.Data.Models;
using Dashonboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Dashonboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashonboardController : ControllerBase
    {
        private readonly ILogger<DashonboardController> _logger;
        private readonly IWorkerService _workerService;

        public DashonboardController(ILogger<DashonboardController> logger,
            IWorkerService workerService)
        {
            _logger = logger;
            _workerService = workerService;
        }

        [HttpGet]
        public async Task<IActionResult> Analyze(DashonboardRequest request)
        {
            _logger.LogInformation($"Anaylzing specified request. {request}");
            var successful = await _workerService.RunAsync();
            _logger.LogInformation($"Work completed.");
            if (successful)
            {
                return Ok("Done!");
            }
            return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
        }
    }
}
