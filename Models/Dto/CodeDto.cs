
namespace APX.Models.Dto
{
    public class CodeDto
    {
        public string Kind{ get; set; }
        public string SortOrder { get; set; }
        public string NameT { get; set; }
        public string Content { get; set; }
    }


    public class CreateCodeDto : CodeDto
    {
        public string Id { get; set; }
    }


    public class UpdateCodeDto : CodeDto
    {
    }
}