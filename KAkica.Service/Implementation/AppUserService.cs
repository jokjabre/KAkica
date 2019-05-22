using AutoMapper;
using KAkica.Communication.AppUser;
using KAkica.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAkica.Service.Implementation
{
    public class AppUserService : IKakicaService<AppUserRequest, AppUserResponse>
    {
        private KAkicaDbContext m_context;
        private IMapper m_mapper;
        public AppUserService(KAkicaDbContext context, IMapper mapper)
        {
            m_context = context;
            m_mapper = mapper;
        }

        public AppUserResponse Create(AppUserRequest item)
        {
            throw new NotImplementedException();
        }

        public Task<AppUserResponse> CreateAsync(AppUserRequest item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppUserResponse> GetAll()
        {
            var res = m_context.AppUsers
                .Include(u => u.AppUserPoopers)
                .ToList();
            var a = m_mapper.Map<AppUserResponse>(res[0]);
            return m_mapper.Map<IEnumerable<AppUserResponse>>(res);
        }

        public Task<IEnumerable<AppUserResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public AppUserResponse GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AppUserResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public AppUserResponse Update(AppUserRequest item)
        {
            throw new NotImplementedException();
        }

        public Task<AppUserResponse> UpdateAsync(AppUserRequest item)
        {
            throw new NotImplementedException();
        }
    }
}
