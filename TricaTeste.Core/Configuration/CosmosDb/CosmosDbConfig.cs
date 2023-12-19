using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net;
using Trinca.Infra.Data;



namespace Trinca.Core.Configuration.CosmosDb
{
    public static class CosmosDbConfig
    {
        public static void  ConfigureCosmosDb(this IServiceCollection service, IConfiguration configuration)
        {


            var endpointUrl = configuration["CosmosDbConfig:Url"];
            var primaryKey = configuration["CosmosDbConfig:PrimaryKey"];
            var databaseName = configuration["CosmosDbConfig:DataBaseId"];
            var connectionString = configuration["CosmosDbConfig:PrimaryConnectionString"];
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            
            
            service.AddDbContext<EFContext>(options =>
            {
                var cosmosClientOptions = new CosmosClientOptions
                {
                    ApplicationName = databaseName,
                    IdleTcpConnectionTimeout = TimeSpan.FromMinutes(1),
                };
                options.UseCosmos(endpointUrl, primaryKey, databaseName,
                    options =>
                    {

                        options.ConnectionMode(ConnectionMode.Direct);
                        options.WebProxy(new WebProxy());
                        options.LimitToEndpoint(false);
                        options.Region(Regions.BrazilSoutheast);
                        options.GatewayModeMaxConnectionLimit(32);
                        options.MaxRequestsPerTcpConnection(8);
                        options.MaxTcpConnectionsPerEndpoint(1);
                        options.IdleTcpConnectionTimeout(TimeSpan.FromSeconds(60));
                        options.OpenTcpConnectionTimeout(TimeSpan.FromMinutes(1));
                        options.RequestTimeout(TimeSpan.FromMinutes(1));
                    })
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
                    .UseLoggerFactory(loggerFactory);
            });
        }
    }
}