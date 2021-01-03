using Dashonboard.Data.Models;
using Dashonboard.Services.Interfaces;
using System.Threading.Tasks;

namespace Dashonboard.Services
{
    public class DashboardService : IDashboardService
    {
        public async Task<bool> CreateAsync(DashboardData dashboardData)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<DashboardData> GetInternalJsonAsync(string identifer)
        {
            throw new System.NotImplementedException();
        }

        public DashboardData Merge(DashboardData existingDashboard, DashboardData newDashboard)
        {
            throw new System.NotImplementedException();
        }
    }
}
