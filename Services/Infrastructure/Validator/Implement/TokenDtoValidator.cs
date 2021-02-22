
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
                .NotNull()
                .NotBlank();
        }
    }


    /* Usage:
    |  using Validator.Fluent;
    |
    |  CreateTokenDtoValidator validator = new CreateTokenDtoValidator(dto);
    |  bool isValidated = validator.IsValidated();
    |  List<ValidationError> errors = validator.GetErrors();
    */
    public class CreateTokenDtoValidator : TokenDtoValidator
    {
        public CreateTokenDtoValidator(TokenDto dto) : base(dto)
        {
        }


        protected override void Validate()
        {
            base.Validate();
            this.ValidateCreatedUser();
        }


        private void ValidateCreatedUser()
        {
            this._validator.SetArg("Token.CreatedUser", this._dto.CreatedUser)
                .NotNull()
                .NotBlank()
                .MaxLength(50);
        }
    }


    /* Usage:
    |  using Validator.Fluent;
    |
    |  UpdateTokenDtoValidator validator = new UpdateTokenDtoValidator(dto);
    |  bool isValidated = validator.IsValidated();
    |  List<ValidationError> errors = validator.GetErrors();
    */
    public class UpdateTokenDtoValidator : TokenDtoValidator
    {
        public UpdateTokenDtoValidator(TokenDto dto) : base(dto)
        {
        }


        protected override void Validate()
        {
            base.Validate();
            this.ValidateUpdatedUser();
        }


        private void ValidateUpdatedUser()
        {
            this._validator.SetArg("Token.UpdatedUser", this._dto.UpdatedUser)
                .NotNull()
                .NotBlank()
                .MaxLength(50);
        }
    }
}