using Dashonboard.Data.Models;
using System.Threading.Tasks;

namespace Dashonboard.Services.Interfaces
{
    /// <summary>
    /// Handles all actions with managing interactions with the Dashboard
    /// </summary>
    public interface IDashboardService
    {
        /// <summary>
        /// Grabs the specified dashboard id in-order to perform necessary work
        /// </summary>
        /// <returns>string representation of the dashboard identifier</returns>
        Task<string> GetAsync();

        /// <summary>
        /// From the specified identifier, returns data back pertaining to the dashboard in JSON form
        /// </summary>
        /// <returns>Internal representation of the Dashboard internals</returns>
        Task<DashboardData> GetInternalJsonAsync(string identifer);

        /// <summary>
        /// Defines how the dashboard will be created from the specified data
        /// </summary>
        /// <returns>boolean of whether the dashboard was created or not</returns>
        Task<bool> CreateAsync(DashboardData dashboardData);

        /// <summary>
        /// Defines how the dashboard data will be represneted from existing form and the new contents
        /// </summary>
        /// <returns>The merged copy of both data sets</returns>
        DashboardData Merge(DashboardData existingDashboard, DashboardData newDashboard);
    }
}
