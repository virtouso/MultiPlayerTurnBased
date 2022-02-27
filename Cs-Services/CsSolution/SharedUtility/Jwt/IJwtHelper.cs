using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SharedUtility.Jwt
{
   public interface IJwtHelper
    {
        public string GenerateJwtToken(ObjectId userId);
        public ObjectId? ValidateJwtToken(string token);
    }
}
