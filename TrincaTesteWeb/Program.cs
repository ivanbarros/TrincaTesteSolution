using Trinca.Core.Configuration.CosmosDb;
using Trinca.Core.Configuration.Jwt;
using Trinca.Core.Configuration.MediatorConfig;
using Trinca.Infra.Configuration.DependencyInjection;
using Trinca.Infra.Configuration.Swagger;

namespace TrincaWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllers();           
            builder.Services.ConfigureDependenciesRepositories();
            builder.Services.ConfigureDependenciesService(builder.Configuration);
            builder.Services.ConfigureCosmosDb(builder.Configuration);
            builder.Services.ConfigureMediator();
            builder.Services.AddAutoMapper(typeof(Program));         
            builder.Services.AddSwaggerFramework(builder.Environment, builder.Configuration);
            builder.Services.ConfigureToken(builder.Configuration);


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
