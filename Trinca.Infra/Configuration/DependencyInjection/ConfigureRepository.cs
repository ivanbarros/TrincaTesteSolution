using Microsoft.Extensions.DependencyInjection;
using Trinca.Infra.Repositories;
using Trinca.Infra.Repositories.Base;
using TrincaTeste.Domain.Interfaces.Repoisitories;
using TrincaTeste.Domain.Interfaces.Repoisitories.BaseRepository;

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
