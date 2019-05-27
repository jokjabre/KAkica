
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KAkica.Service
{
    public interface IKakicaService<TRequest, TResponse> : IDisposable 
        where TRequest : class
        where TResponse : class
    {
        IEnumerable<TResponse> GetAll();
        TResponse GetById(int id);
        TResponse Create(TRequest item);
        TResponse Update(int id, TRequest item);
        bool Delete(int id);

        Task<IEnumerable<TResponse>> GetAllAsync();
        Task<TResponse> GetByIdAsync(int id);
        Task<TResponse> CreateAsync(TRequest item);
        Task<TResponse> UpdateAsync(int id, TRequest item);
        Task<bool> DeleteAsync(int id);

    }
}
