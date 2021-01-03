using Dashonboard.Data.Models;
using Dashonboard.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashonboard.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IAnalyzerService _analyzerService;
        private readonly IDashboardService _dashboardService;

        public WorkerService(IAnalyzerService analyzerService,
            IDashboardService dashboardService)
        {
            _analyzerService = analyzerService;
            _dashboardService = dashboardService;
        }

        public async Task<bool> RunAsync(string organization, string repository, string commitHash)
        {
            var dashboard = await _dashboardService.GetAsync();
            var panelData = await _dashboardService.GetInternalJsonAsync(dashboard);
            var results = await _analyzerService.PerformAnalysisAsync(organization, repository, commitHash);
            foreach (var result in results)
            {
                var newPanelData = new DashboardData();
                var finalResults = _dashboardService.Merge(panelData, newPanelData);
                var success = await _dashboardService.CreateAsync(finalResults);
                if (!success)
                    return false;
            }
            return true;
        }

        public async Task<IList<AnalysisResult>> DebugAsync(string organization, string repository, string commitHash)
        {
            return await _analyzerService.PerformAnalysisAsync(organization, repository, commitHash);
        }
    }
}
