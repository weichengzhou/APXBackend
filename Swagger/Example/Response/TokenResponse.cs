
using System.Collections.Generic;

using APX.Models;

namespace APX.Swagger.Example
{
    public class CreateTokenResponseExample : SucceedResponseExample<Token>
    {
        public override Token Result
        {
            get => TokenExampleFactory.CreateToken();
        }


        public override string Message
        {
            get => "Token is created.";
        }
    }


    public class GetTokensResponseExample : SucceedResponseExample<List<Token>>
    {
        public override List<Token> Result
        {
            get
            {
                return new List<Token>
                {
                    TokenExampleFactory.CreateToken()
                };
            }
        }


        public override string Message
        {
            get => "Find 1 records.";
        }
    }


    public class GetTokenResponseExample : SucceedResponseExample<Token>
    {
        public override Token Result
        {
            get => TokenExampleFactory.CreateToken();
        }


        public override string Message
        {
            get => "Find Token SEQ 1.";
        }
    }
}