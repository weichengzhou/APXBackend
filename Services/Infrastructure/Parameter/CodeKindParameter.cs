
using Validator.Fluent;

namespace APX.Services.Parameter
{
    public class CodeKindParameter : BaseParameter
    {
        protected override void ValidateParameter()
        {
            StringValidator stringValidator = new StringValidator();
            stringValidator.SetArg("CodeKind.NameT", this.NameT)
                .MaxLength(20);
            this._errors.AddRange(stringValidator.Errors);
        }


        public string NameT { get; set; }
    }


    public class CreatedCodeKindParameter : CodeKindParameter
    {
        protected override void ValidateParameter()
        {
            base.ValidateParameter();
            StringValidator stringValidator = new StringValidator();
            stringValidator.SetArg("CodeKind.Name", this.Name)
                .NotNull()
                .NotBlank()
                .MaxLength(10);
            this._errors.AddRange(stringValidator.Errors);
        }

        
        public string Name { get; set; }
    }


    public class UpdatedCodeKindParameter : CodeKindParameter
    {
    }
}