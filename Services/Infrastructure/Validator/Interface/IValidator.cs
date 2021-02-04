
using System.Collections.Generic;

using Validator.Fluent;

namespace APX.Services.Validator
{
    public interface IValidator
    {
        bool IsValidated();
        
        List<ValidationError> GetErrors();
    }
}