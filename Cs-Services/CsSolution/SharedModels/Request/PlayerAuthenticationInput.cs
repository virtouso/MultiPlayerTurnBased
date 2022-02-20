using FluentValidation;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayerAuthentication.Models
{
    public class PlayerAuthenticationInput
    {
        [BsonId]
        public string Id;// its the token id
        public string UniqueName;
        public string GooglePlayId;
        public string Password;
        public string DeviceId;

        public bool IsTemp;
        public bool IsValid;
        public Validator ModelValidator = new Validator();
        public PlayerAuthenticationInput(string id, string uniqueName, string googlePlayId, string password, string deviceId)
        {
            Id = id;
            UniqueName = uniqueName;
            GooglePlayId = googlePlayId;
            Password = password;
            DeviceId = deviceId;
        }



        public class Validator : AbstractValidator<PlayerAuthenticationInput>
        {
            public Validator()
            {
                RuleFor(x => x.Id).NotNull().NotEmpty();
                RuleFor(x => x.UniqueName).NotNull().NotEmpty();
                RuleFor(x => x.Password).NotNull().MinimumLength(6).MaximumLength(12);
                RuleFor(x => x.GooglePlayId).NotNull();
                RuleFor(x=>x.DeviceId).NotNull().MinimumLength(10).MaximumLength(20);
            }




        }




    }
}
