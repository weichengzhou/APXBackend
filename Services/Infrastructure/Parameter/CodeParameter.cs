
using Validator.Fluent;

namespace APX.Services.Parameter
{
    public class CodeParameter : BaseParameter
    {
        protected override void ValidateParameter()
        {
            StringValidator validator = new StringValidator();
            validator.SetArg("Code.SortOrder", this.SortOrder).MaxLength(7);
            validator.SetArg("Code.NameT", this.NameT).MaxLength(20);
            validator.SetArg("Code.Content", this.Content).MaxLength(50);
            this._errors.AddRange(validator.Errors);
        }


        public string Kind{ get; set; }
        public string SortOrder { get; set; }
        public string NameT { get; set; }
        public string Content { get; set; }
    }


    public class CreatedCodeParameter : CodeParameter
    {
        protected override void ValidateParameter()
        {
            StringValidator validator = new StringValidator();
            validator.SetArg("Code.Id", this.Id)
                .NotNull()
                .NotBlank().
                MaxLength(20);
            validator.SetArg("Code.Kind", this.Kind)
                .NotNull()
                .NotBlank()
                .MaxLength(10);
            this._errors.AddRange(validator.Errors);
        }

        
        public string Id { get; set; }
    }


    public class UpdatedCodeParameter : CodeParameter
    {
        protected override void ValidateParameter()
        {
            StringValidator validator = new StringValidator();
            validator.SetArg("Code.Kind", this.Kind)
                .NotBlank()
                .MaxLength(10);
            this._errors.AddRange(validator.Errors);
        }
    }
}