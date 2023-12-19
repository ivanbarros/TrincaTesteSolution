using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Trinca.Core.Configuration.MediatorConfig
{
    public static class CQRS
    {
        public static void ConfigureMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Trinca.Infra");
            services.AddMediatR(assembly);
        }
    }
}
