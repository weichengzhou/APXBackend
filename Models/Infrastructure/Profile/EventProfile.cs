
using System;

using APX.Models.Dto;

namespace APX.Models.Profile
{
    public class EventProfile : AutoMapper.Profile
    {
        public EventProfile()
        {
            this.CreateMap<CreateEventDto, Event>()
                .ForMember(src => src.CreatedDate, dst => dst.MapFrom(attr => DateTime.Now))
                .ForMember(src => src.UpdatedUser, dst => dst.MapFrom(attr => attr.CreatedUser))
                .ForMember(src => src.UpdatedDate, dst => dst.MapFrom(attr => DateTime.Now));
            this.CreateMap<UpdateEventDto, Event>()
                .ForMember(src => src.UpdatedDate, dst => dst.MapFrom(attr => DateTime.Now));
        }
    }
}