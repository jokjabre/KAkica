using AutoMapper;
using KAkica.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KAkica.Service
{
    public abstract class KakicaBaseService<TModel, TRequest, TResponse> : IKakicaService<TRequest, TResponse>
        where TModel : class
        where TRequest : class
        where TResponse : class
    {
        protected KAkicaDbContext m_context;
        protected IMapper m_mapper;

        public TResponse Create(TRequest item)
        {
            var model = m_mapper.Map<TModel>(item);

            var res = m_context.Set<TModel>().Add(model);

            var changesCount = m_context.SaveChanges();

            return changesCount == 0 ?
                null :
                m_mapper.Map<TResponse>(res.Entity);
        }

        public async Task<TResponse> CreateAsync(TRequest item)
        {
            var model = m_mapper.Map<TModel>(item);

            var res = await m_context.Set<TModel>().AddAsync(model);
            var changesCount = await m_context.SaveChangesAsync();

            return changesCount == 0 ?
                null :
                m_mapper.Map<TResponse>(res.Entity);
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
            m_context.Dispose();
        }

        public IEnumerable<TResponse> GetAll()
        {
            return m_mapper.Map<IEnumerable<TResponse>>(GetAllWithIncludes());
        }

        public async Task<IEnumerable<TResponse>> GetAllAsync()
        {
            var res = await GetAllWithIncludes().ToListAsync();

            return m_mapper.Map<IEnumerable<TResponse>>(res);
        }

        public TResponse GetById(int id)
        {
            var model = m_context.Set<TModel>().Find(id);
            return m_mapper.Map<TResponse>(model);
        }

        public async Task<TResponse> GetByIdAsync(int id)
        {
            var model = await m_context.Set<TModel>().FindAsync(id);
            return m_mapper.Map<TResponse>(model);
        }

        public TResponse Update(int id, TRequest item)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> UpdateAsync(int id, TRequest item)
        {
            throw new NotImplementedException();
        }


        protected abstract IQueryable<TModel> GetAllWithIncludes();
    }
}
