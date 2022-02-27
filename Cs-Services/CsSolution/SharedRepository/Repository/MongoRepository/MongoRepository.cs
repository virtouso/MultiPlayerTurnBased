using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using PlayerAuthentication.Models;
using SharedModels;
using SharedModels.General;
using SharedModels.General.Types;
using SharedRepository.Models;
using SharedRepository.Repository.RedisRepository.References;

namespace SharedRepository
{
    public class MongoRepository : IMongoRepository
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _dataBase;

        public MongoRepository(string userName, string password, string server, string databaseName)
        {
            _mongoClient = new MongoClient($"mongodb://{server}/{databaseName}");
            _dataBase = _mongoClient.GetDatabase(databaseName);
        }





        public async Task<(ResponseType, Player.Progress)> AddServiceToPlayer(ObjectId id, Player.Service service)
        {

            var playerCollection = _dataBase.GetCollection<Player>(CollectionNames.Player);
            var playerFilter = Builders<Player>.Filter.Eq("_id", id);

            var relatedPlayer = playerCollection.Find(playerFilter).First();
            relatedPlayer.GooglePlay = service;
            playerCollection.ReplaceOne(playerFilter, relatedPlayer);
            return (ResponseType.Success, relatedPlayer.PlayerProgress);
        }



        public async Task<(ResponseType, ObjectId, Player.Progress)> GetTokenForInitialPlayer(Player.Identity identity, Player.Service service, Player.Progress initialProgress)
        {

            Player initPlayer = new Player(identity, initialProgress, service);

            bool hasService = service != null;
            Player foundPlayer = null;
            var playerCollection = _dataBase.GetCollection<Player>(CollectionNames.Player);
            if (hasService)
            {
                var playerFilter = Builders<Player>.Filter.Eq("GooglePlayService.Id", service.Id);
                foundPlayer = playerCollection.Find(playerFilter).First();
            }

            if (foundPlayer != null)
            {
                return (ResponseType.Success, foundPlayer.PlayerIdentity.Id, foundPlayer.PlayerProgress);
            }

            playerCollection.InsertOne(initPlayer);

            return (ResponseType.Success,initPlayer.PlayerIdentity.Id,initPlayer.PlayerProgress);


        }
    }
}
