
using Validator.Fluent;

namespace APX.Services.Parameter
{
    public class TokenParameter : BaseParameter
    {
        protected override void ValidateParameter()
        {
        }

        
        public string Body { get; set; }
    }


    public class CreatedTokenParameter : TokenParameter
    {
        protected override void ValidateParameter()
        {
            base.ValidateParameter();
            StringValidator stringValidator = new StringValidator();
            stringValidator.SetArg("Token.Body", this.Body)
                .NotNull();
            stringValidator.SetArg("Token.CreatedUser", this.CreatedUser)
                .NotNull()
                .NotBlank()
                .MaxLength(50);
            this._errors.AddRange(stringValidator.Errors);
        }

        
        public string CreatedUser { get; set; }
    }
}