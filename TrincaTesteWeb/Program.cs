using Trinca.Infra.Configuration.CosmosDb;
using Trinca.Infra.Configuration.DependencyInjection;
using Trinca.Infra.Configuration.Swagger;

namespace TrincaTesteWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
           
            builder.Services.ConfigureDependenciesRepositories();
            builder.Services.ConfigureDependenciesService(builder.Configuration);
            CosmosDbConfig.ConfigureCosmosDb(builder.Services,builder.Configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerFramework(builder.Environment, builder.Configuration);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
