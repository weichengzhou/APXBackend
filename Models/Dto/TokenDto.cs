
namespace APX.Models.Dto
{
    public class TokenDto
    {
        public string Body { get; set; }
    }


    public class CreateTokenDto : TokenDto
    {
        public string CreatedUser { get; set; }
    }


    public class UpdateTokenDto : TokenDto
    {
        public string UpdatedUser { get; set; }
    }
}