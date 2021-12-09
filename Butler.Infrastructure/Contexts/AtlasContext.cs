using Butler.Infrastructure.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Butler.Infrastructure.Contexts
{
    internal class AtlasContext
    {
        public IMongoCollection<Server> Servers;
        public AtlasContext(IConfiguration configuration)
        {
            var mongUrl = new MongoUrl(configuration.GetSection("mongo:connectionString").Value);
            var client = new MongoClient(mongUrl);
            var database = client.GetDatabase(mongUrl.DatabaseName);
            Servers = database.GetCollection<Server>("Servers");
        }
    }
}
