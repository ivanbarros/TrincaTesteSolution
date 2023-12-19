using Microsoft.Extensions.DependencyInjection;
using Trinca.Domain.Interfaces.Repoisitories;
using Trinca.Domain.Interfaces.Repoisitories.BaseRepository;
using Trinca.Infra.Repositories;
using Trinca.Infra.Repositories.Base;

namespace Trinca.Infra.Configuration.DependencyInjection
{
    public static class ConfigureRepository
    {

        public static void ConfigureDependenciesRepositories(this IServiceCollection services)
        {

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITaskRepository, TaskRepository>();
        }
    }
}
