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
            var successful = await _workerService.RunAsync(request.Organization, request.RepositoryName, request.CommitHash);
            _logger.LogInformation($"Work completed.");
            if (successful)
            {
                return Ok("Done!");
            }
            return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        [Route("/debug")]
        public async Task<IActionResult> Debug(string org, string repo, string commitHash)
        {
            return Ok(await _workerService.DebugAsync(org, repo, commitHash));
        }
    }
}
