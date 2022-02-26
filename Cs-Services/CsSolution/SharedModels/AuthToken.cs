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
        public ObjectId ObjectId;
        public string Token;
        public ObjectId PlayerId;
        public DateTime InitiationDate;

        public AuthToken(ObjectId objectId, string token, ObjectId playerId, DateTime initiationDate)
        {
            ObjectId = objectId;
            Token = token;
            PlayerId = playerId;
            InitiationDate = initiationDate;
        }
    }
}
