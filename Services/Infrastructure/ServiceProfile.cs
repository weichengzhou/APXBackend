
using System;

using APX.Models;
using APX.Models.Dto;

namespace APX.Services.Profile
{
    public class ServiceProfile : AutoMapper.Profile
    {
        public ServiceProfile()
        {
            this.CreateMap<CodeKindDto, CodeKind>()
                .ForMember(s => s.Name, d => d.MapFrom(a => a.Name.PadRight(10)));
            this.CreateMap<CodeDto, Code>();
            this.CreateMap<EventDto, Event>()
                .ForMember(s => s.UpdatedDate, d => d.MapFrom(a => DateTime.Now));
            this.CreateMap<TokenDto, Token>()
                .ForMember(s => s.UpdatedDate, d => d.MapFrom(a => DateTime.Now));
        }
    }
}