/*
Basic response for api.
Success : True or False
Message
Result : API response corresponse object here.
*/

namespace APXBackend.Controllers.Response
{
    public interface IResponse
    {
        bool Success { get; set; }
        string Message { get; set; }
        object Result { get; set; }
    }


    public class ErrorResponse : IResponse
    {
        public ErrorResponse(string message)
        {
            this.Success = false;
            this.Message = message;
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }
    }


    public class SucceedResponse : IResponse
    {
        public SucceedResponse(string message="", object result=null)
        {
            this.Success = true;
            this.Message = message;
            this.Result = result;
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }
    }
}