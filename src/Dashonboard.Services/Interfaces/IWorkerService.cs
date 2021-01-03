using System.Threading.Tasks;

namespace Dashonboard.Services.Interfaces
{
    public interface IWorkerService
    {
        /// <summary>
        /// Defines how the necessary run should go
        /// </summary>
        /// <returns>Flag to indicate whether the run was successful or not</returns>
        Task<bool> RunAsync();
    }
}
