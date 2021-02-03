
using System;

using Validator.Fluent;

namespace APX.Services.Parameter
{
    public class EventParameter : BaseParameter
    {
        protected override void ValidateParameter()
        {
            StringValidator stringValidator = new StringValidator();
            stringValidator.SetArg("Event.IPAddress", this.IPAddress)
                .MaxLength(20);
            stringValidator.SetArg("Event.Status", this.Status)
                .MaxLength(255);
            stringValidator.SetArg("Event.Desc", this.Desc)
                .MaxLength(255);
            this._errors.AddRange(stringValidator.Errors);
        }
        

        public string APISystem { get; set; }
        public string APIName { get; set; }
        public string APIVersion { get; set; }
        public string Source { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Flow { get; set; }
        public string IPAddress { get; set; }
        public string Status { get; set; }
        public string Desc { get; set; }
    }


    public class CreatedEventParameter : EventParameter
    {
        protected override void ValidateParameter()
        {
            base.ValidateParameter();
            StringValidator stringValidator = new StringValidator();
            stringValidator.SetArg("Event.APISystem", this.APISystem)
                .NotNull()
                .NotBlank()
                .MaxLength(16);
            stringValidator.SetArg("Event.APIName", this.APIName)
                .NotNull()
                .NotBlank()
                .MaxLength(64);
            stringValidator.SetArg("Event.APIVersion", this.APIVersion)
                .MaxLength(8);
            stringValidator.SetArg("Event.Source", this.Source)
                .NotNull()
                .NotBlank()
                .MaxLength(64);
            stringValidator.SetArg("Event.Name", this.Name)
                .MaxLength(64);
            stringValidator.SetArg("Event.Time", this.Time)
                .NotNull()
                .NotBlank()
                .DateTimeFormat();
            stringValidator.SetArg("Event.Flow" ,this.Flow)
                .NotNull()
                .NotBlank()
                .MaxLength(30);
            stringValidator.SetArg("Event.CreatedUser", this.CreatedUser)
                .NotNull()
                .NotBlank()
                .MaxLength(50);
            this._errors.AddRange(stringValidator.Errors);
        }


        public DateTime GetTime()
        {
            return DateTime.Parse(this.Time);    
        }
        

        public string CreatedUser { get; set; }
    }


    public class UpdatedEventParameter : EventParameter
    {
        protected override void ValidateParameter()
        {
            base.ValidateParameter();
            StringValidator stringValidator = new StringValidator();
            stringValidator.SetArg("Event.APISystem", this.APISystem)
                .NotBlank()
                .MaxLength(16);
            stringValidator.SetArg("Event.APIName", this.APIName)
                .NotBlank()
                .MaxLength(64);
            stringValidator.SetArg("Event.APIVersion", this.APIVersion)
                .MaxLength(8);
            stringValidator.SetArg("Event.Source", this.Source)
                .NotBlank()
                .MaxLength(64);
            stringValidator.SetArg("Event.Name", this.Name)
                .MaxLength(64);
            stringValidator.SetArg("Event.Time", this.Time)
                .NotBlank()
                .DateTimeFormat();
            stringValidator.SetArg("Event.Flow" ,this.Flow)
                .NotBlank()
                .MaxLength(30);
            stringValidator.SetArg("Event.UpdatedUser", this.UpdatedUser)
                .NotNull()
                .NotBlank()
                .MaxLength(50);
            this._errors.AddRange(stringValidator.Errors);
        }


        public DateTime? GetTime()
        {
            if(this.Time is null)
                return null;
            else
                return DateTime.Parse(this.Time);    
        }


        public string UpdatedUser { get; set; }
    }
}