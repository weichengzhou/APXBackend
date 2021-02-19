
using Swashbuckle.AspNetCore.Filters;

using APX.Models.Dto;

namespace APX.Swagger.Example
{
    public class CreateTokenRequestExample : IExamplesProvider<TokenDto>
    {
        public TokenDto GetExamples()
        {
            return new TokenDto
            {
                Body = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9",
                CreatedUser = "Frank"
            };
        }
    }


    public class UpdateTokenRequestExample : IExamplesProvider<TokenDto>
    {
        public TokenDto GetExamples()
        {
            return new TokenDto
            {
                Body = "eyJ1c2VyX2lkIjoyLCJ1c2VybmFtZSI6InJvY2si",
                UpdatedUser = "Bob"
            };
        }
    }
}