
using System.Collections.Generic;

using APX.Models.Dto;

using Validator.Fluent;

namespace APX.Services.Validator
{
    public class EventDtoValidator : AbstractValidator
    {
        protected EventDto _dto;
        protected StringValidator _validator;

        public EventDtoValidator(EventDto dto)
        {
            this._dto = dto;
            this._validator = new StringValidator();
        }

        protected override void Validate()
        {
            this.ValidateAPISystem();
            this.ValidateAPIName();
            this.ValidateAPIVersion();
            this.ValidateSource();
            this.ValidateName();
            this.ValidateTime();
            this.ValidateFlow();
            this.ValidateIPAddress();
            this.ValidateStatus();
            this.ValidateDesc();
        }


        public override List<ValidationError> GetErrors()
        {
            return this._validator.Errors;
        }
        

        protected void ValidateAPISystem()
        {
            this._validator.SetArg("Event.APISystem", this._dto.APISystem)
                .NotNull()
                .NotBlank()
                .MaxLength(16);
        }


        protected void ValidateAPIName()
        {
            this._validator.SetArg("Event.APIName", this._dto.APIName)
                .NotNull()
                .NotBlank()
                .MaxLength(64);
        }


        protected void ValidateAPIVersion()
        {
            this._validator.SetArg("Event.APIVersion", this._dto.APIVersion)
                .MaxLength(8);
        }


        protected void ValidateSource()
        {
            this._validator.SetArg("Event.Source", this._dto.Source)
                .NotNull()
                .NotBlank()
                .MaxLength(64);
        }


        protected void ValidateName()
        {
            this._validator.SetArg("Event.Name", this._dto.Name)
                .MaxLength(64);
        }


        protected void ValidateTime()
        {
            this._validator.SetArg("Event.Time", this._dto.Time)
                .NotNull()
                .NotBlank()
                .DateTimeFormat();
        }


        protected void ValidateFlow()
        {
            this._validator.SetArg("Event.Flow" ,this._dto.Flow)
                .NotNull()
                .NotBlank()
                .MaxLength(30);
        }


        protected void ValidateIPAddress()
        {
            this._validator.SetArg("Event.IPAddress", this._dto.IPAddress)
                .MaxLength(20);
        }


        protected void ValidateStatus()
        {
            this._validator.SetArg("Event.Status", this._dto.Status)
                .MaxLength(255);
        }


        protected void ValidateDesc()
        {
            this._validator.SetArg("Event.Desc", this._dto.Desc)
                .MaxLength(255);
        }
    }


    public class CreateEventDtoValidator : EventDtoValidator
    {
        public CreateEventDtoValidator(EventDto dto) : base(dto)
        {
        }


        protected override void Validate()
        {
            base.Validate();
            this.ValidateCreatedUser();
        }


        protected void ValidateCreatedUser()
        {
            this._validator.SetArg("Event.CreatedUser", this._dto.CreatedUser)
                .NotNull()
                .NotBlank()
                .MaxLength(50);
        }
    }


    public class UpdateEventDtoValidator : EventDtoValidator
    {
        public UpdateEventDtoValidator(EventDto dto) : base(dto)
        {
        }


        protected override void Validate()
        {
            base.Validate();
            this.ValidateUpdateUser();
        }


        protected void ValidateUpdateUser()
        {
            this._validator.SetArg("Event.UpdatedUser", this._dto.UpdatedUser)
                .NotNull()
                .NotBlank()
                .MaxLength(50);
        }
    }
}