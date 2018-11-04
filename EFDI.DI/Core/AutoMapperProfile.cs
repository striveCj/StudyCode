using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using EFDI.Core.Data;
using EFDI.DI.Models.Dto;

namespace EFDI.DI.Core
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(d => d.FirstName, m => m.MapFrom(f => f.UserProfile.FirstName))
                .ForMember(d => d.LastName, m => m.MapFrom(f => f.UserProfile.LastName))
                .ForMember(d => d.Address, m => m.MapFrom(f => f.UserProfile.Address));
            CreateMap<UserDto, User>().ForMember(d => d.UserProfile, m => m.MapFrom(f => f));

            CreateMap<UserDto, UserProfile>()
                .ForMember(d => d.FirstName, m => m.MapFrom(f => f.FirstName))
                .ForMember(d => d.LastName, m => m.MapFrom(f => f.LastName))
                .ForMember(d => d.Address, m => m.MapFrom(f => f.Address));
        }
    }
}