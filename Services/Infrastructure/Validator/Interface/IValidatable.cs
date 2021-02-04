
using System.Collections.Generic;

using Validator.Fluent;

namespace APX.Services.Validator
{
    public interface IValidatable
    {
        bool IsValidated();
        
        List<ValidationError> GetErrors();
    }
}