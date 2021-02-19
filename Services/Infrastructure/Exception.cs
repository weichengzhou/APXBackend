
using System;
using System.Linq;
using System.Collections.Generic;

using Validator.Fluent;

namespace APX.Services.Exceptions
{
    public abstract class ServiceError : System.Exception
    {
        protected string _message = null;
        protected string _defaultMessage = "";


        public ServiceError(string message=null)
        {
            this._message = message;
        }


        public string ErrorCode { protected set; get; }


        public override string Message
        {
            get{
                if(this._message is null)
                    return this._defaultMessage;
                else
                    return this._message;
            }
        }
    }


    public class InputValidatedError : ServiceError
    {
        public InputValidatedError(List<ValidationError> errors, string message=null)
        {
            this.ErrorCode = "E01";
            this._defaultMessage = String.Join(
                "<br>", errors.Select(e => e.Message));
        }
    }


    public class EventNotFoundError : ServiceError
    {
        public EventNotFoundError(string seq, string message=null)
        {
            this.ErrorCode = "E02";
            this._defaultMessage = String.Format("Cannot find Event Seq `{0}`.", seq);
        }
    }


    public class TokenNotFoundError : ServiceError
    {
        public TokenNotFoundError(string seq, string message=null)
        {
            this.ErrorCode = "E03";
            this._defaultMessage = String.Format("Cannot find Token Seq `{0}`.", seq);
        }
    }


    public class CodeKindNotFoundError : ServiceError
    {
        public CodeKindNotFoundError(string name, string message=null)
        {
            this.ErrorCode = "E04";
            this._defaultMessage = String.Format("Cannot find CodeKind Name `{0}`.", name);
        }
    }


    public class CodeKindIsExistError : ServiceError
    {
        public CodeKindIsExistError(string name, string message=null)
        {
            this.ErrorCode = "E05";
            this._defaultMessage = String.Format("Codekind Name `{0}` is exist.", name);
        }
    }


    public class CodeNotFoundError : ServiceError
    {
        public CodeNotFoundError(string id, string message=null)
        {
            this.ErrorCode = "E06";
            this._defaultMessage = String.Format("Cannot find Code ID `{0}`.", id);
        }
    }


    public class CodeIsExistError : ServiceError
    {
        public CodeIsExistError(string id, string message=null)
        {
            this.ErrorCode = "E07";
            this._defaultMessage = String.Format("Code ID `{0}` is exist.", id);
        }
    }
}