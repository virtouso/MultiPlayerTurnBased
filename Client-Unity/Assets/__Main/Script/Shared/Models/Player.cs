

namespace SharedModels
{
    public class Player
    {

        public Identity PlayerIdentity;
      
        public Progress PlayerProgress;
        public bool IsGuest;
        public Player(Identity playerIdentity, Progress playerProgress)
        {
            PlayerIdentity = playerIdentity;
            PlayerProgress = playerProgress;
         
        }




        public class Identity
        {
            
            public string Id;

            public string UserId;
            public string Email;
            public string TokenId;
            public string AuthCode;

            public Identity()
            {

            }

            public Identity(string id, string userId, string email, string tokenId, string authCode)
            {
                Id = id;
                UserId = userId;
                Email = email;
                TokenId = tokenId;
                AuthCode = authCode;
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
