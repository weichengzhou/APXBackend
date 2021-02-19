
using Swashbuckle.AspNetCore.Filters;

using APX.Models.Dto;

namespace APX.Swagger.Example
{
    public class CreateCodeRequestExample : IExamplesProvider<CodeDto>
    {
        public CodeDto GetExamples()
        {
            return new CodeDto
            {
                ID = "APX",
                Kind = "System",
                SortOrder = "1",
                NameT = "資料交換",
                Content = "紀錄API存取Log"
            };
        }
    }


    public class UpdateCodeRequestExample : IExamplesProvider<CodeDto>
    {
        public CodeDto GetExamples()
        {
            return new CodeDto
            {
                Kind = "System",
                SortOrder = "2",
                NameT = "紀錄資料",
                Content = ""
            };
        }
    }
}