
using System.Collections.Generic;

using APX.Models.Dto;

using Validator.Fluent;

namespace APX.Services.Validator
{
    public class CodeDtoValidator : AbstractValidator
    {
        private CodeDto _dto;
        private StringValidator _validator;

        public CodeDtoValidator(CodeDto dto)
        {
            this._dto = dto;
            this._validator = new StringValidator();
        }


        protected override void Validate()
        {
            this.ValidateId();
            this.ValidateKind();
            this.ValidateSortOrder();
            this.ValidateNameT();
            this.ValidateContent();
        }


        public override List<ValidationError> GetErrors()
        {
            return this._validator.Errors;
        }


        private void ValidateId()
        {
            this._validator.SetArg("Code.Id", this._dto.ID)
                .NotNull()
                .NotBlank().
                MaxLength(20);
        }


        private void ValidateKind()
        {
            this._validator.SetArg("Code.Kind", this._dto.Kind)
                .NotNull()
                .NotBlank()
                .MaxLength(10);
        }


        private void ValidateSortOrder()
        {
            this._validator.SetArg("Code.SortOrder", this._dto.SortOrder)
                .MaxLength(7);
        }


        private void ValidateNameT()
        {
            this._validator.SetArg("Code.NameT", this._dto.NameT)
                .MaxLength(20);
        }


        private void ValidateContent()
        {
            this._validator.SetArg("Code.Content", this._dto.Content)
                .MaxLength(50);
        }
    }
}