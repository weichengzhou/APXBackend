
using Swashbuckle.AspNetCore.Filters;

using APX.Models.Dto;

namespace APX.Swagger.Example
{
    public class CreateCodeKindRequestExample : IExamplesProvider<CodeKindDto>
    {
        public CodeKindDto GetExamples()
        {
            return new CodeKindDto
            {
                Name = "System",
                NameT = "系統代號"
            };
        }
    }


    public class UpdateCodeKindRequestExample : IExamplesProvider<CodeKindDto>
    {
        public CodeKindDto GetExamples()
        {
            return new CodeKindDto
            {
                NameT = "系統名稱"
            };
        }
    }
}