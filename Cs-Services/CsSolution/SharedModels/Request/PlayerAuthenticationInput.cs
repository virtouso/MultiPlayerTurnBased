using FluentValidation;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayerAuthentication.Models
{
    public class PlayerAuthenticationInput
    {

        public string TokenId;// its the token id
        public string UniqueName;
        public string ServiceId;
        public string Email;
        public string JwtToken;


        public Validator ModelValidator = new Validator();

        public PlayerAuthenticationInput(string tokenId, string uniqueName, string serviceId, string email, string jwtToken)
        {
            TokenId = tokenId;
            UniqueName = uniqueName;
            ServiceId = serviceId;
            Email = email;
            JwtToken = jwtToken;
        }

        public class Validator : AbstractValidator<PlayerAuthenticationInput>
        {
            public Validator()
            {
                RuleFor(x => x.TokenId).NotNull().NotEmpty();
                RuleFor(x => x.UniqueName).NotNull().NotEmpty();
                RuleFor(x => x.ServiceId).NotNull();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x=>x.JwtToken).NotNull().NotEmpty();
            }



        }




    }
}
