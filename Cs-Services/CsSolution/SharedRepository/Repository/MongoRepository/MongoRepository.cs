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





        public async Task<(ResponseType, Player.Progress)> AddServiceToPlayer(string authToken, Player.Service service)
        {
            var tokenCollection = _dataBase.GetCollection<AuthToken>(CollectionNames.Token);

            var tokenFilter = Builders<AuthToken>.Filter.Eq(nameof(AuthToken.Token), authToken);
            var relatedDocument = tokenCollection.Find(tokenFilter).First();
            ObjectId playerId = relatedDocument.PlayerId;


            var playerCollection = _dataBase.GetCollection<Player>(CollectionNames.Player);
            var playerFilter = Builders<Player>.Filter.Eq("_id", playerId);

            var relatedPlayer = playerCollection.Find(playerFilter).First();
            relatedPlayer.AddService(service);
            playerCollection.ReplaceOne(playerFilter, relatedPlayer);
            return (ResponseType.Success, relatedPlayer.PlayerProgress);
        }



        public async Task<(ResponseType, string)> GetTokenForInitialPlayer(Player.Identity identity, Player.Service service, Player.Progress initialProgress)
        {
           
       
                Player player= new Player(identity,initialProgress,service);
            


        }
    }
}
