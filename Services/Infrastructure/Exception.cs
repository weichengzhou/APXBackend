
using System;
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
            foreach(ValidationError error in errors)
                this._defaultMessage += error.Message + "<br>";
        }
    }


    public class EventNotFoundError : ServiceError
    {
        public EventNotFoundError(string seq, string message=null)
        {
            this.ErrorCode = "E02";
            this._defaultMessage = String.Format("Cannot find event seq `{0}`.", seq);
        }
    }


    public class TokenNotFoundError : ServiceError
    {
        public TokenNotFoundError(string seq, string message=null)
        {
            this.ErrorCode = "E03";
            this._defaultMessage = String.Format("Cannot find token seq `{0}`.", seq);
        }
    }


    public class CodeKindNotFoundError : ServiceError
    {
        public CodeKindNotFoundError(string name, string message=null)
        {
            this.ErrorCode = "E04";
            this._defaultMessage = String.Format("Cannot find codeKind name `{0}`.", name);
        }
    }


    public class CodeKindIsExistError : ServiceError
    {
        public CodeKindIsExistError(string name, string message=null)
        {
            this.ErrorCode = "E05";
            this._defaultMessage = String.Format("Codekind name `{0}` is exist.", name);
        }
    }


    public class CodeNotFoundError : ServiceError
    {
        public CodeNotFoundError(string id, string message=null)
        {
            this.ErrorCode = "E06";
            this._defaultMessage = String.Format("Cannot find code id `{0}`.", id);
        }
    }


    public class CodeIsExistError : ServiceError
    {
        public CodeIsExistError(string id, string message=null)
        {
            this.ErrorCode = "E07";
            this._defaultMessage = String.Format("Code id `{0}` is exist.", id);
        }
    }
}