using Dashonboard.Data.Models;
using Dashonboard.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Octokit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashonboard.Services
{
    public class AnalyzerService : IAnalyzerService
    {
        private readonly ILogger<AnalyzerService> _logger;
        private readonly IOptions<BasicAuthCredentials> _options;

        public AnalyzerService(ILogger<AnalyzerService> logger,
            IOptions<BasicAuthCredentials> options)
        {
            _logger = logger;
            _options = options;
        }

        public async Task<IList<AnalysisResult>> PerformAnalysisAsync(string organization, string repository, string commitHash, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Starting analysis.");
            var results = await GitClient(organization, repository, commitHash, cancellationToken);
            return results;
        }

        private async Task<IList<AnalysisResult>> GitClient(string organization, string repository, string commitHash, CancellationToken cancellationToken = default)
        {
            var github = new GitHubClient(new ProductHeaderValue("Dashonboard"));
            github.Credentials = new Credentials(_options.Value.Username, _options.Value.Password);
            var results = await github.Repository.Commit.Get(organization, repository, commitHash);
            return new List<AnalysisResult>();
        }
    }
}
