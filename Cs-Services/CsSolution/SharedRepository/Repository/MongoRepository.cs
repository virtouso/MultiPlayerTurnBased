using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using SharedModels;
using SharedModels.General;

namespace SharedRepository.Main
{
    public class MongoRepository : IMongoRepository
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _dataBase;

        public MongoRepository()
        {
            _mongoClient = new MongoClient("mongodb+srv://moeen:moeen777@localhost/TurnBasedMultiPlayer");
            _dataBase = _mongoClient.GetDatabase("MultiPlayerTurnBased");
        }


        public ReturnData<string> FindPlayerId(PlayerAuthenticationInput input)
        {
            var players = _dataBase.GetCollection<BsonDocument>("Players");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("_id", input._id);

            var document= players.Find(filter).FirstOrDefault();


            var player = new Player(input);
            if (document is null)
            {
                string json = JsonConvert.SerializeObject(player);
                players.InsertOne( BsonDocument.Parse(json));
            }

            return  new ReturnData<string>(player.PlayerIdentity._id,ReturnDataTypes.Ok)  ;

        }




    }
}
