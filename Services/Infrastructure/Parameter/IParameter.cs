
using System.Collections.Generic;

using Validator.Fluent;

namespace APX.Services.Parameter
{
    public interface IParameter
    {
        bool IsValidated();
        List<ValidationError> GetErrors();
    }
}