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
        public Tracking PlayerTracking;
        public Progress PlayerProgress;

        public Player(Identity playerIdentity, Tracking playerTracking, Progress playerProgress)
        {
            PlayerIdentity = playerIdentity;
            PlayerTracking = playerTracking;
            PlayerProgress = playerProgress;
        }




        public class Identity
        {
            [BsonId]
            public ObjectId Id;
            public string UniqueName;
            public string Password;

            public Identity()
            {

            }
            public Identity(ObjectId id, string uniqueName, string password)
            {
                Id = id;
                UniqueName = uniqueName;
                Password = password;
            }
        }

        public class Tracking
        {
            public List<Device> Devices;
            public string GooglePlayId;
            public Tracking(List<Device> devices)
            {
                Devices = devices;
            }

            public Tracking(Device Device)
            {
                Devices = new List<Device> { Device };
            }

            public void AddDevice(Device Device)
            {
                Devices.Add(Device);
            }

            public class Device
            {
                public string DeviceId;
                public string Version;
                public string Brand;
                public string OperatingSystem;

                public Device(string deviceId = null, string version = null, string brand = null, string operatingSystem = null)
                {
                    DeviceId = deviceId;
                    Version = version;
                    Brand = brand;
                    OperatingSystem = operatingSystem;
                }
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
