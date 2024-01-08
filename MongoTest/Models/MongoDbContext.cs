using MongoDB.Driver;

namespace MongoTest.Models
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDB"));
            _database = client.GetDatabase(configuration["ConnectionStrings:DatabaseName"]);
        }

        public IMongoCollection<Todo> TodoItems => _database.GetCollection<Todo>("Todo");
    }
}
