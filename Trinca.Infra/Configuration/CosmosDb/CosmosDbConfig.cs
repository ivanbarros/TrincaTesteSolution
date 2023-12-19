using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Net;
using Trinca.Infra.Data;



namespace Trinca.Infra.Configuration.CosmosDb
{
    public static class CosmosDbConfig
    {
        public static async Task ConfigureCosmosDb(IServiceCollection service, IConfiguration configuration)
        {

                var endpointUrl = configuration["CosmosDbConfig:Url"];
                var primaryKey = configuration["CosmosDbConfig:PrimaryKey"];
                var databaseName = configuration["CosmosDbConfig:DataBaseId"];

            //service.AddSingleton((provider) =>
            //{

            //    var cosmosClientOptions = new CosmosClientOptions
            //    {
            //        ApplicationName = databaseName
            //    };


            //    var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            //    var cosmosClient = new CosmosClient(endpointUrl, primaryKey, cosmosClientOptions);
            //    cosmosClient.ClientOptions.ConnectionMode = ConnectionMode.Gateway;
            //    return cosmosClient;

            //});
            service.AddDbContext<EFContext>(options =>
            {
                var cosmosClientOptions = new CosmosClientOptions
                {
                    ApplicationName = databaseName
                };
                options.UseCosmos(endpointUrl, primaryKey, databaseName,
                    options =>
                    {
                        
                        options.ConnectionMode(ConnectionMode.Direct);
                        options.WebProxy(new WebProxy());
                        //options.LimitToEndpoint();
                        //options.Region(Regions.BrazilSoutheast);
                        options.GatewayModeMaxConnectionLimit(32);
                        options.MaxRequestsPerTcpConnection(8);
                        options.MaxTcpConnectionsPerEndpoint(1);
                        options.IdleTcpConnectionTimeout(TimeSpan.FromSeconds(60));
                        options.OpenTcpConnectionTimeout(TimeSpan.FromMinutes(1));
                        options.RequestTimeout(TimeSpan.FromMinutes(1));
                    });

            });
        }
    }
}