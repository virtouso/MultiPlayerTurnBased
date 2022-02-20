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
        public string TokenId;
        public string PlayerId;

        public AuthToken( string playerId, string tokenId=null)
        {
            TokenId = tokenId;
            PlayerId = playerId;
        }
    }
}
