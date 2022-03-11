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





        public async Task<(ResponseType, ObjectId, Player.Progress)> InitializePlayer(bool isGuest, Player.Identity identity, Player.Progress initialProgress)
        {

            Player initPlayer = new Player(identity, initialProgress);


            Player foundPlayer = null;
            var playerCollection = _dataBase.GetCollection<Player>(CollectionNames.Player);
            if (!isGuest)
            {
                var playerFilter = Builders<Player>.Filter.Eq("Identity:Email", identity.Email);
                foundPlayer = playerCollection.Find(playerFilter).First();
            }

            if (foundPlayer == null || isGuest)
            {
                return (ResponseType.Success, foundPlayer.PlayerIdentity.Id, foundPlayer.PlayerProgress);
                playerCollection.InsertOne(initPlayer);
                return (ResponseType.Success, initPlayer.PlayerIdentity.Id, initPlayer.PlayerProgress);
            }

            return (ResponseType.Success, foundPlayer.PlayerIdentity.Id, initPlayer.PlayerProgress);




        }
    }
}
