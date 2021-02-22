
using System.Collections.Generic;

using APX.Models.Dto;

using Validator.Fluent;

namespace APX.Services.Validator
{
    /* Usage:
    |  using Validator.Fluent;
    |
    |  CodeKindDtoValidator validator = new CodeKindDtoValidator(dto);
    |  bool isValidated = validator.IsValidated();
    |  List<ValidationError> errors = validator.GetErrors();
    */
    public class CodeKindDtoValidator : AbstractValidator
    {
        private CodeKindDto _dto;
        private StringValidator _validator;


        public CodeKindDtoValidator(CodeKindDto dto)
        {
            this._dto = dto;
            this._validator = new StringValidator();
        }


        protected override void Validate()
        {
            this.ValidateName();
            this.ValidateNameT();
        }


        public override List<ValidationError> GetErrors()
        {
            return this._validator.Errors;
        }


        private void ValidateName()
        {
            this._validator.SetArg("CodeKind.Name", this._dto.Name)
                .NotNull()
                .NotBlank()
                .MaxLength(10);
        }


        private void ValidateNameT()
        {
            this._validator.SetArg("CodeKind.NameT", this._dto.NameT)
                .MaxLength(20);
        }
    }
}