using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class AuthToken
    {
        [BsonId]
        public ObjectId TokenId;
        public ObjectId PlayerId;

        public AuthToken(ObjectId playerId, ObjectId tokenId )
        {
            TokenId = tokenId;
            PlayerId = playerId;
        }
    }
}
