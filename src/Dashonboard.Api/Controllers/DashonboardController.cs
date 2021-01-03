using Dashonboard.Data.Models;
using Dashonboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Dashonboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashonboardController : ControllerBase
    {
        private readonly ILogger<DashonboardController> _logger;
        private readonly IAnalyzerService _analyzerService;

        public DashonboardController(ILogger<DashonboardController> logger,
            IAnalyzerService analyzerService)
        {
            _logger = logger;
            _analyzerService = analyzerService;
        }

        [HttpGet]
        public async Task<IActionResult> Analyze(DashonboardRequest request)
        {
            _logger.LogInformation($"Anaylzing specified request. {request}");
            var results = await _analyzerService.PerformAnalysisAsync();
            _logger.LogInformation($"Work completed.");
            return Ok("Done!");
        }
    }
}
