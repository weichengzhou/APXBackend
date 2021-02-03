
using System.Collections.Generic;

using Validator.Fluent;

namespace APX.Services.Parameter
{
    public abstract class BaseParameter : IParameter
    {
        protected List<ValidationError> _errors;

        public BaseParameter()
        {
            this._errors = new List<ValidationError>();
        }


        public bool IsValidated()
        {
            this.ValidateParameter();
            if(this._errors.Count == 0)
                return true;
            else
                return false;
        }


        protected abstract void ValidateParameter();


        public List<ValidationError> GetErrors()
        {
            return this._errors;
        }
    }
}