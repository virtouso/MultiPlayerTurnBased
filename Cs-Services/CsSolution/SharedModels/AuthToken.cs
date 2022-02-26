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
        public DateTime InitiationDate;

        public AuthToken(ObjectId objectId, string token, DateTime initiationDate)
        {
            ObjectId = objectId;
            Token = token;
            InitiationDate = initiationDate;
        }
    }
}
