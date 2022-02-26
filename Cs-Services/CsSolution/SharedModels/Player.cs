﻿using MongoDB.Bson;
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
        public Service GooglePlay;
        public Progress PlayerProgress;
        public bool IsGuest;
        public Player(Identity playerIdentity, Progress playerProgress, Service googlePlay)
        {
            PlayerIdentity = playerIdentity;
            PlayerProgress = playerProgress;
            GooglePlay = googlePlay;

            IsGuest = (GooglePlay is null) ? true : false;
        }




        public class Identity
        {
            [BsonId]
            public ObjectId Id;

            public string UniqueName;

            public Identity()
            {

            }
            public Identity(string uniqueName)
            {
                UniqueName = uniqueName;
            }
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
