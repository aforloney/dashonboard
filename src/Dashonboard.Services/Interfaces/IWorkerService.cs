using Dashonboard.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashonboard.Services.Interfaces
{
    public interface IWorkerService
    {
        /// <summary>
        /// Defines how the necessary run should go
        /// </summary>
        /// <returns>Flag to indicate whether the run was successful or not</returns>
        Task<bool> RunAsync(string organization, string repository, string commitHash);

        /// <summary>
        /// Testing functionality
        /// </summary>
        /// <param name="org"></param>
        /// <param name="repo"></param>
        /// <param name="commitHash"></param>
        /// <returns></returns>
        Task<IList<AnalysisResult>> DebugAsync(string org, string repo, string commitHash);
    }
}
