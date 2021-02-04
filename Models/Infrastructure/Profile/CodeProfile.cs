
using APX.Models.Dto;

namespace APX.Models.Profile
{
    public class CodeProfile : AutoMapper.Profile
    {
        public CodeProfile()
        {
            this.CreateMap<CreateCodeDto, Code>();
            this.CreateMap<CodeDto, Code>();
        }
    }
}