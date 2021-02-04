
using System.Collections.Generic;

using APX.Models.Dto;

using Validator.Fluent;

namespace APX.Services.Validator
{
    public class CodeKindDtoValidator : AbstractValidator
    {
        protected CodeKindDto _dto;
        protected StringValidator _validator;


        public CodeKindDtoValidator(CodeKindDto dto)
        {
            this._dto = dto;
            this._validator = new StringValidator();
        }


        protected override void Validate()
        {
            this.ValidateNameT();
        }


        public override List<ValidationError> GetErrors()
        {
            return this._validator.Errors;
        }


        public void ValidateNameT()
        {
            this._validator.SetArg("CodeKind.NameT", this._dto.NameT)
                .MaxLength(20);
        }
    }


    public class CreateCodeKindDtoValidator : CodeKindDtoValidator
    {
        public CreateCodeKindDtoValidator(CreateCodeKindDto dto) : base(dto)
        {
        }


        protected override void Validate()
        {
            base.Validate();
            this.ValidateName();
        }


        protected void ValidateName()
        {
            this._validator.SetArg("CodeKind.Name",
                ((CreateCodeKindDto)this._dto).Name)
                .NotNull()
                .NotBlank()
                .MaxLength(10);
        }
    }


    public class UpdateCodeKindDtoValidator : CodeKindDtoValidator
    {
        public UpdateCodeKindDtoValidator(UpdateCodeKindDto dto) : base(dto)
        {
        }
    }
}