using AutoMapper;
using KAkica.Communication.AppUser;
using KAkica.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAkica.Service.Implementation
{
    public class AppUserService : KakicaBaseService<AppUser, AppUserRequest, AppUserResponse>
    {
        public AppUserService(KAkicaDbContext context, IMapper mapper)
        {
            m_context = context;
            m_mapper = mapper;
        }


        protected override IQueryable<AppUser> GetAllWithIncludes()
        {
            return m_context.AppUsers
                .Include(u => u.AppUserPoopers)
                    .ThenInclude(aup => aup.Pooper).AsQueryable();
        }

        public async Task<bool> AssignPooper(int ownerId, int pooperId)
        {
            var user = await m_context.AppUsers.FindAsync(ownerId);
            var pooper = await m_context.Poopers.FindAsync(pooperId);

            if(user != null && pooper != null)
            {
                m_context.AppUserPoopers.Add(new AppUserPooper()
                {
                    AppUser = user,
                    Pooper = pooper
                });

                return (await m_context.SaveChangesAsync()) > 0;
            }
            return false;
        }
    }
}
