using Dashonboard.Data.Models;
using Dashonboard.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashonboard.Services
{
    public class AnalyzerService : IAnalyzerService
    {
        private readonly ILogger<AnalyzerService> _logger;

        public AnalyzerService(ILogger<AnalyzerService> logger)
        {
            _logger = logger;
        }

        public Task<IList<AnalysisResult>> PerformAnalysisAsync()
        {
            _logger.LogInformation("Starting analysis.");
            throw new System.NotImplementedException();
        }
    }
}
