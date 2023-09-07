using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Quiz.Infrastructure.Data
{
    public abstract class MongoDbBaseContext
    {
        protected readonly IMongoDatabase _database;

        protected virtual string PrefixTable
        {
            get;
        } = string.Empty;


        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return _database.GetCollection<TEntity>(PrefixTable);
        }

        public MongoDbBaseContext(IOptionsMonitor<MongoDatabaseSettings> settings)
        {         
            MongoClientSettings mongoClientSettings = MongoClientSettings.FromUrl(new MongoUrl(settings.CurrentValue.ConnectionString));
     
            MongoClient mongoClient = new MongoClient(mongoClientSettings);
            if (mongoClient != null)
            {
                _database = mongoClient.GetDatabase(settings.CurrentValue.DatabaseName);
            }
        }

    }
}
