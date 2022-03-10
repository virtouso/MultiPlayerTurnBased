using FluentValidation;
using MongoDB.Bson.Serialization.Attributes;

namespace PlayerAuthentication.Models
{
    public class PlayerAuthenticationInput
    {
        public bool IsGuest;
        public string TokenId;
        public string UserId;
        public string Email;
        public string AuthCode;

        public Validator ModelValidator = new Validator();


        public PlayerAuthenticationInput()
        {

        }

        public PlayerAuthenticationInput(bool isGuest, string tokenId, string userId, string email, string authCode)
        {
            IsGuest = isGuest;
            TokenId = tokenId;
            UserId = userId;
            Email = email;
            AuthCode = authCode;
        }

        public class Validator : AbstractValidator<PlayerAuthenticationInput>
        {
            public Validator()
            {
                RuleFor(x => x.TokenId).NotNull().NotEmpty();
                RuleFor(x => x.UserId).NotNull().NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x=>x.AuthCode).NotNull().NotEmpty();
            }



        }




    }
}
