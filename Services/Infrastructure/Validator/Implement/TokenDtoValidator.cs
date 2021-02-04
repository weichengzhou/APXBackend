
using System.Collections.Generic;

using APX.Models.Dto;

using Validator.Fluent;

namespace APX.Services.Validator
{
    public class TokenDtoValidator : AbstractValidator
    {
        protected TokenDto _dto;
        protected StringValidator _validator;

        public TokenDtoValidator(TokenDto dto)
        {
            this._dto = dto;
            this._validator = new StringValidator();
        }

        protected override void Validate()
        {
            this.ValidateBody();
        }


        public override List<ValidationError> GetErrors()
        {
            return this._validator.Errors;
        }


        protected void ValidateBody()
        {
            this._validator.SetArg("Token.Body", this._dto.Body)
                .NotNull();
        }
    }


    public class CreateTokenDtoValidator : TokenDtoValidator
    {
        public CreateTokenDtoValidator(CreateTokenDto dto) : base(dto)
        {
        }


        protected override void Validate()
        {
            base.Validate();
            this.ValidateCreatedUser();
        }


        protected void ValidateCreatedUser()
        {
            this._validator.SetArg("Token.CreatedUser",
                ((CreateTokenDto)this._dto).CreatedUser)
                .NotNull()
                .NotBlank()
                .MaxLength(50);
        }
    }
}