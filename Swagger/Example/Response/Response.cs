
using Swashbuckle.AspNetCore.Filters;

using APX.Controllers.Response;

namespace APX.Swagger.Example
{
    public class ErrorResponseExample : IExamplesProvider<ErrorResponse>
    {
        public ErrorResponse GetExamples()
        {
            return new ErrorResponse("Error message");
        }
    }


    public abstract class SucceedResponseExample<T>
        : IExamplesProvider<SucceedResponse<T>>
    {
        abstract public T Result{ get; }


        abstract public string Message{ get; }


        public SucceedResponse<T> GetExamples()
        {
            return new SucceedResponse<T>(this.Result, this.Message);
        }
    }
}