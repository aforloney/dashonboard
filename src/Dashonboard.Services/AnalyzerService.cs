using Dashonboard.Data.Models;
using Dashonboard.Services.Extenstions;
using Dashonboard.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Octokit;
using ParseDiff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Dashonboard.Services
{
    public class AnalyzerService : IAnalyzerService
    {
        private readonly ILogger<AnalyzerService> _logger;
        private readonly IOptions<BasicAuthCredentials> _options;

        private readonly Regex _timingRegEx;
        private readonly string _timerRegExp = @"\.Timer\(\""(.+)\""\)";

        public AnalyzerService(ILogger<AnalyzerService> logger,
            IOptions<BasicAuthCredentials> options)
        {
            _logger = logger;
            _options = options;
            _timingRegEx = new Regex(_timerRegExp);
        }

        public async Task<IList<AnalysisResult>> PerformAnalysisAsync(string organization, string repository, string commitHash, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Starting analysis.");
            var analysis = new List<AnalysisResult>();

            var github = new GitHubClient(new ProductHeaderValue("Dashonboard"));
            github.Credentials = new Credentials(_options.Value.Username, _options.Value.Password);
            var results = await github.Repository.Commit.Get(organization, repository, commitHash);

            foreach (var result in results.Files)
            {
                var patch = GetQualifiedPatch(result.Patch);
                var diffs = Diff.Parse(patch);
                if (diffs == null)
                    continue;

                foreach (var diff in diffs.SelectMany(f => f.Chunks))
                {
                    // with the lines that have been added, check for metrics
                    var additions = FilterTimers(diff.Changes.GetAdds());
                    if (additions.Any())
                        analysis.AddRange(additions.Select(adds => new AnalysisResult
                        {
                            ActionType = "CREATE",
                            MetricType = "Timer",
                            MetricName = _timingRegEx.Match(adds.Content).Groups[1].Value,
                        }));

                    // with the lines that have been deleted, check for metrics to remove
                    var deletions = FilterTimers(diff.Changes.GetDeletes());
                    if (deletions.Any())
                        analysis.AddRange(deletions.Select(adds => new AnalysisResult
                        {
                            ActionType = "DELETE",
                            MetricType = "Timer",
                            MetricName = _timingRegEx.Match(adds.Content).Groups[1].Value,
                        }));
                }
            }

            return analysis;
        }

        /// <summary>
        /// The library requires a header above the @ notation of context changes so let's add one to play nicely
        /// </summary>
        /// <param name="patch"></param>
        /// <returns></returns>
        private string GetQualifiedPatch(string patch)
        {
            return $"diff --git{Environment.NewLine}{patch}";
        }

        private IList<LineDiff> FilterTimers(IEnumerable<LineDiff> diff)
        {
            return diff.Where(chg => _timingRegEx.Match(chg.Content).Success).ToList();
        }
    }
}
