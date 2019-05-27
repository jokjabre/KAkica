using AutoMapper;
using KAkica.Communication.Pooper;
using KAkica.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAkica.Service.Implementation
{
    public class PooperService : KakicaBaseService<Pooper, PooperRequest, PooperResponse>
    {
        public PooperService(KAkicaDbContext context, IMapper mapper)
        {
            m_context = context;
            m_mapper = mapper;
        }


        protected override IQueryable<Pooper> GetAllWithIncludes()
        {
            return m_context.Poopers
                .Include(u => u.AppUserPoopers)
                    .ThenInclude(aup => aup.AppUser).AsQueryable();
        }
    }
}
