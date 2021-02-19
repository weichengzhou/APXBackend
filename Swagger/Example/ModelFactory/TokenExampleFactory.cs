
using System;

using APX.Models;

namespace APX.Swagger.Example
{
    public class TokenExampleFactory
    {
        static public Token CreateToken()
        {
            return new Token
            {
                SEQ = 1,
                Body = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9",
                CreatedUser = "Frank",
                CreatedDate = new DateTime(2021, 2, 20, 11, 3, 4),
                UpdatedUser = "Frank",
                UpdatedDate = new DateTime(2021, 2, 20, 11, 3, 4)
            };
        }


        static public Token UpdateToken()
        {
            return new Token
            {
                SEQ = 1,
                Body = "eyJ1c2VyX2lkIjoyLCJ1c2VybmFtZSI6InJvY2si",
                CreatedUser = "Frank",
                CreatedDate = new DateTime(2021, 2, 20, 11, 3, 4),
                UpdatedUser = "Bob",
                UpdatedDate = new DateTime(2021, 2, 23, 6, 11, 15)
            };
        }
    }
}