
using System;

using APX.Models.Dto;

namespace APX.Models.Profile
{
    public class TokenProfile : AutoMapper.Profile
    {
        public TokenProfile()
        {
            this.CreateMap<CreateTokenDto, Token>()
                .ForMember(src => src.CreatedDate, dst => dst.MapFrom(attr => DateTime.Now))
                .ForMember(src => src.UpdatedUser, dst => dst.MapFrom(attr => attr.CreatedUser))
                .ForMember(src => src.UpdatedDate, dst => dst.MapFrom(attr => DateTime.Now));
            this.CreateMap<UpdateTokenDto, Token>()
                .ForMember(src => src.UpdatedDate, dst => dst.MapFrom(attr => DateTime.Now));
        }
    }
}