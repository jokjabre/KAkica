using AutoMapper;
using KAkica.Communication.AppUser;
using KAkica.Communication.Pooper;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.Models.AppUser, AppUserResponse>()
                .ForMember(m => m.Poopers, opts => opts.MapFrom(o => o.AppUserPoopers))
                .ReverseMap();
            CreateMap<Domain.Models.AppUser, AppUserRequest>().ReverseMap();

            CreateMap<Domain.Models.Pooper, PooperResponse>().ReverseMap();
            CreateMap<Domain.Models.Pooper, PooperRequest>().ReverseMap();

            CreateMap<AppUserRequest, AppUserResponse>().ReverseMap();
            CreateMap<PooperRequest, PooperResponse>().ReverseMap();
        }
    }
}
