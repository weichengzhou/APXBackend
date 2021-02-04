
using System.Collections.Generic;

using Validator.Fluent;

namespace APX.Services.Validator
{
    public abstract class AbstractValidator : IValidator
    {
        public bool IsValidated()
        {
            this.Validate();
            if(this.GetErrors().Count == 0)
                return true;
            else
                return false;
        }


        protected abstract void Validate();


        public abstract List<ValidationError> GetErrors();
    }
}