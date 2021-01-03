using Dashonboard.Data.Models;
using Dashonboard.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dashonboard.Services.Register
{
    public static class RegisterServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IWorkerService, WorkerService>();
            services.AddScoped<IAnalyzerService, AnalyzerService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.Configure<BasicAuthCredentials>(options => configuration.GetSection("BasicAuth").Bind(options));
        }
    }
}
