using KAkica.Communication.Pooper;
using KAkica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KAkica.Service.Implementation
{
    public class PooperService : IKakicaService<PooperRequest, PooperResponse>
    {
        private KAkicaDbContext m_context;
        public PooperService(KAkicaDbContext context)
        {
            m_context = context;
        }
        public PooperResponse Create(PooperRequest item)
        {
            throw new NotImplementedException();
        }

        public Task<PooperResponse> CreateAsync(PooperRequest item)
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
            m_context.Dispose();
        }

        public IEnumerable<PooperResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PooperResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public PooperResponse GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PooperResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public PooperResponse Update(PooperRequest item)
        {
            throw new NotImplementedException();
        }

        public Task<PooperResponse> UpdateAsync(PooperRequest item)
        {
            throw new NotImplementedException();
        }
    }
}
