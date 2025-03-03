using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuth.Core.Dtos;
using UserAuth.Core.Entities;

namespace UserAuth.Core.Mapper
{
    public class MappingRegisterToAuthResponseProfile : Profile
    {
        public MappingRegisterToAuthResponseProfile()
        {
            CreateMap<ApplicationUser, AuthenticationResponse>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Token, opt => opt.Ignore())
                .ForMember(dest => dest.Success, opt => opt.Ignore());  
        }
    }
}
