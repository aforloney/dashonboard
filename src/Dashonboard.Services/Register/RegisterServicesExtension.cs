using Dashonboard.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dashonboard.Services.Register
{
    public static class RegisterServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IWorkerService, WorkerService>();
            services.AddScoped<IAnalyzerService, AnalyzerService>();
            services.AddScoped<IDashboardService, DashboardService>();
        }
    }
}
