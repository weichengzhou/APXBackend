
using APX.Models.Dto;

namespace APX.Models.Profile
{
    public class CodeKindProfile : AutoMapper.Profile
    {
        public CodeKindProfile()
        {
            this.CreateMap<CreateCodeKindDto, CodeKind>();
            this.CreateMap<CodeKindDto, CodeKind>();
        }
    }
}