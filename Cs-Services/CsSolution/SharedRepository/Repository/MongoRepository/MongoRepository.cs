using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using SharedModels;
using SharedModels.General;

namespace SharedRepository
{
    public class MongoRepository : IMongoRepository
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _dataBase;

        public MongoRepository(string userName, string password, string server, string databaseName)
        {
            _mongoClient = new MongoClient($"mongodb+srv://{userName}:{password}@{server}/{databaseName}");
            _dataBase = _mongoClient.GetDatabase(databaseName);
        }







    }
}
