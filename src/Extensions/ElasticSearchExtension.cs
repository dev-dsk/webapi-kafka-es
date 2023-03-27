using Nest;
using Permissions.API.Entities;

namespace Permissions.API.Extensions
{
    public static class ElasticSearchExtension
    {
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            
            var baseUrl = configuration["ElasticSettings:baseUrl"];
            var defaultIndex = configuration["ElasticSettings:defaultIndex"];

            var settings = new ConnectionSettings(new Uri(baseUrl ?? ""))
                .PrettyJson()
                .DefaultIndex(defaultIndex);           
            
            AddDefaultMappings(settings);
            
            var client = new ElasticClient(settings);
            
            services.AddSingleton<IElasticClient>(client);
            
            CreateIndex(client, defaultIndex);
        }

        private static void AddDefaultMappings(ConnectionSettings settings)
        {
            settings.DefaultMappingFor<Permission>(m => m.Ignore(p => p.PermissionDate));
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName, index => index.Map<Permission>(x => x.AutoMap()));
        }
    }
}
