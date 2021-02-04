
namespace APX.Models.Dto
{
    public class CodeKindDto
    {
        public string NameT { get; set; }
    }


    public class CreateCodeKindDto : CodeKindDto
    {
        public string Name { get; set; }
    }
}