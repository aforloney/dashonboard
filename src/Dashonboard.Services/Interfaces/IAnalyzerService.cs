using Dashonboard.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashonboard.Services.Interfaces
{
    /// <summary>
    /// Handles all the functionality for analyzing changes for a specific commit hash
    /// </summary>
    public interface IAnalyzerService
    {
        /// <summary>
        /// Defines how the analysis will be handled
        /// </summary>
        /// <returns></returns>
        Task<IList<AnalysisResult>> PerformAnalysisAsync();
    }
}
