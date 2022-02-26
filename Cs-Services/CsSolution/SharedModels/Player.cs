using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Player
    {

        public Identity PlayerIdentity;
        public List<Service> Services;
        public Progress PlayerProgress;
        public bool IsGuest;
        public Player(Identity playerIdentity, Progress playerProgress, Service service)
        {
            PlayerIdentity = playerIdentity;
            PlayerProgress = playerProgress;
            AddService(service);

            IsGuest = (!Services?.Any() != true) ? true : false;
        }




        public class Identity
        {
            [BsonId]
            public ObjectId Id;
            public string UniqueName;

            public Identity()
            {

            }
            public Identity(ObjectId id, string uniqueName)
            {
                Id = id;
                UniqueName = uniqueName;
            }
        }


        public void AddService(Service service)
        {
            if (Services is null)
                Services = new List<Service>();
            Services.Add(service);
        }
        public class Service
        {
            string Id;
            String Email;

            public Service(string id, string email)
            {
                Id = id;
                Email = email;
            }
        }


        public class Progress
        {
            public int Gold;
            public int Silver;
            public int Level;
            public int Experience;

            public Progress(int gold, int silver, int level, int experience)
            {
                Gold = gold;
                Silver = silver;
                Level = level;
                Experience = experience;
            }
        }



    }
}
