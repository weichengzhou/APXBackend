
using System.Collections.Generic;

using APX.Models.Dto;

using Validator.Fluent;

namespace APX.Services.Validator
{
    public class CodeDtoValidator : AbstractValidator
    {
        protected CodeDto _dto;
        protected StringValidator _validator;

        public CodeDtoValidator(CodeDto dto)
        {
            this._dto = dto;
            this._validator = new StringValidator();
        }


        protected override void Validate()
        {
            this.ValidateKind();
            this.ValidateSortOrder();
            this.ValidateNameT();
            this.ValidateContent();
        }


        public override List<ValidationError> GetErrors()
        {
            return this._validator.Errors;
        }


        protected void ValidateKind()
        {
            this._validator.SetArg("Code.Kind", this._dto.Kind)
                .NotNull()
                .NotBlank()
                .MaxLength(10);
        }


        protected void ValidateSortOrder()
        {
            this._validator.SetArg("Code.SortOrder", this._dto.SortOrder)
                .MaxLength(7);
        }


        protected void ValidateNameT()
        {
            this._validator.SetArg("Code.NameT", this._dto.NameT)
                .MaxLength(20);
        }


        protected void ValidateContent()
        {
            this._validator.SetArg("Code.Content", this._dto.Content)
                .MaxLength(50);
        }
    }


    public class CreateCodeDtoValidator : CodeDtoValidator
    {
        public CreateCodeDtoValidator(CreateCodeDto dto) : base(dto)
        {
        }


        protected override void Validate()
        {
            base.Validate();
            this.ValidateId();
        }


        protected void ValidateId()
        {
            this._validator.SetArg("Code.Id",
                ((CreateCodeDto)this._dto).Id)
                .NotNull()
                .NotBlank().
                MaxLength(20);
        }
    }


    public class UpdateCodeDtoValidator : CodeDtoValidator
    {
        public UpdateCodeDtoValidator(UpdateCodeDto dto) : base(dto)
        {
        }
    }
}