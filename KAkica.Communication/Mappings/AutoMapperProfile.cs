using AutoMapper;
using KAkica.Communication.AppUser;
using KAkica.Communication.Pooper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KAkica.Communication.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.Models.AppUser, AppUserRequest>().ReverseMap();
            CreateMap<Domain.Models.Pooper, PooperRequest>().ReverseMap();

            CreateMap<Domain.Models.AppUser, AppUserDto>().ReverseMap();
            CreateMap<Domain.Models.Pooper, PooperDto>().ReverseMap();

            CreateMap<AppUserRequest, AppUserResponse>().ReverseMap();
            CreateMap<PooperRequest, PooperResponse>().ReverseMap();

            CreateMap<Domain.Models.AppUser, AppUserResponse>()
                .ForMember(m => m.Poopers, opts => opts.MapFrom(o => o.AppUserPoopers.Select(p => p.Pooper)))
                .ReverseMap();

            CreateMap<Domain.Models.Pooper, PooperResponse>()
                .ForMember(m => m.Owners, opts => opts.MapFrom(o => o.AppUserPoopers.Select(p => p.AppUser)))
                .ReverseMap();

            CreateMap<IdentityUser, Domain.Models.AppUser>()
                .ForMember(u => u.Username, opts => opts.MapFrom(i => i.UserName));
        }
    }
}
