using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trinca.Domain.Interfaces.Services;
using Trinca.Domain.Interfaces.Services.BaseService;
using Trinca.Infra.Services;
using Trinca.Infra.Services.Base;

namespace Trinca.Infra.Configuration.DependencyInjection
{
    public static class ConfigureService
    {
        public static void ConfigureDependenciesService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<ITaskService, TaskService>();
        }
    }
}
