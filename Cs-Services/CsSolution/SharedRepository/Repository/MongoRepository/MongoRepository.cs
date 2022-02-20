using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using PlayerAuthentication.Models;
using SharedModels;
using SharedModels.General;
using SharedModels.General.Types;
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

        public async Task<ReturnData<string>> GetTokenForGuestPlayer(Player.Tracking.Device deviceInfo, Player.Progress initialProgress)
        {
            var playerCollection = _dataBase.GetCollection<Player>(CollectionNames.Player);
            Player player = new Player(new Player.Identity(), new Player.Tracking(deviceInfo), initialProgress);
            await playerCollection.InsertOneAsync(player);

            AuthToken token = new AuthToken(player.PlayerIdentity.Id,new ObjectId());

            var tokenCollection = _dataBase.GetCollection<AuthToken>(CollectionNames.Token);
            await tokenCollection.InsertOneAsync(token);

            return new ReturnData<string>(token.TokenId.ToString());
        }
    }
}
